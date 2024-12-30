using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireBall : MonoBehaviour
{
    public float speed;
    public float lifetime;
    public float damage;

    private bool expload;
    //private Collider2D collider;
    private Animator anim;

    private void Start()
    {
        anim = GetComponent<Animator>();
    }
    void Update()
    {
        transform.Translate(Vector2.up * speed * Time.deltaTime);
        lifetime -= Time.deltaTime;
        if ( lifetime <= 0)
        {
            Destroy(gameObject);
        }
        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Wall") 
        {
            speed = 0f;
            anim.SetTrigger("Explode");
            if (!expload)
            {
                gameObject.transform.localScale += new Vector3(2f, 2f, 2f);
                expload = true;
            }
            Destroy(gameObject, 0.4f);
        }

        if (other.gameObject.tag == "Enemy")
        {
            other.GetComponent<Base_Enemy>().TakeDamage(damage);
            speed = 0f;
            anim.SetTrigger("Explode");
            if (!expload)
            {
                gameObject.transform.localScale += new Vector3(2f, 2f, 2f);
                expload = true;
            }
            
            Destroy(gameObject, 0.4f);
        }
    }
}
