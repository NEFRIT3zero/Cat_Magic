using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireBall : MonoBehaviour
{
    public float speed;
    public float lifetime;
    public float damage;
    public Rigidbody2D rb;

    private bool expload;
    //private Collider2D collider;
    private Animator anim;

    private void Start()
    {
        anim = GetComponent<Animator>();
        rb.velocity = transform.up * speed;
    }
    void Update()
    {
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
            rb.velocity = Vector2.zero;
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
            rb.velocity = Vector2.zero;
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
