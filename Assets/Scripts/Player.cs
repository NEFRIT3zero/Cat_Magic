using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float speed;
    public GameObject spell;
    public Staff staff;
    public GameObject player;

    private Vector2 moveVelocity;
    private Vector2 moveInput;
    private Rigidbody2D rb;
    private Animator anim;



    private bool canMove = true;
    private bool left = false;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        Move();
        if (moveVelocity != Vector2.zero) { anim.SetBool("IsRun", true); } else { anim.SetBool("IsRun", false); }

        }

    private void FixedUpdate()
    {
        rb.MovePosition(rb.position + moveVelocity * Time.deltaTime);
        
    }

    void Move()
    {
        if (canMove)
        {
            moveInput = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
            if (moveInput.x > 0 && left)
            {
                transform.localScale = new Vector3(transform.localScale.x *-1, transform.localScale.y, transform.localScale.z);
                staff.offset = 0;
                left = false;
            }
            else if (moveInput.x < 0 && !left)
            {
                transform.localScale = new Vector3(transform.localScale.x * -1, transform.localScale.y, transform.localScale.z);
                staff.offset = 180;
                left = true;
            }
            moveVelocity = moveInput.normalized * speed;
        }
    }

    //void Roll()
    //{
    //    canMove = false;
    //    Vector3 difference = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
    //    float rotZ = Mathf.Atan2(difference.y, difference.x) * Mathf.Rad2Deg;
    //    transform.rotation = Quaternion.Euler(0, 0, rotZ -90);
    //    rb.MovePosition(Input.mou + moveVelocity * 10);
    //    canMove = true;
    //}

}
