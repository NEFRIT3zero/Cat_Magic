using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Staff : MonoBehaviour
{
    public float offset;
    public float speed;
    public GameObject spell;
    public Transform point;

    private float check;

    private float timeBtwCast;
    public float startTimeBtwCast;

    // Update is called once per frame
    void Update()
    {
        //Floating();
        Vector3 difference = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
        float rotZ = Mathf.Atan2(difference.y, difference.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0, 0, rotZ + offset);

        if (timeBtwCast <= 0)
        {
            if (Input.GetMouseButton(0))
            {
                Instantiate(spell, point.position, point.rotation);
                timeBtwCast = startTimeBtwCast;
            }
        }
        else
        {
            timeBtwCast -= Time.deltaTime;
        }
    }

    //void Floating()
    //{
    //    float i = 1;
    //    if (check > 10)
    //    {
    //        i = -1;
    //    }
    //    if (check < -10)
    //    {
    //        i = 1;
    //    }
    //    check = check + i * Time.deltaTime;
    //    //transform.Translate(new Vector2(transform.position.x, transform.position.y + i * speed));
    //    transform.position = Vector2.MoveTowards(transform.position, new Vector2(transform.position.x, transform.position.y + i * speed), i * Time.deltaTime);

    //}
}
