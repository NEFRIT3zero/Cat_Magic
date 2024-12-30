using UnityEngine;

public class Base_Enemy : MonoBehaviour
{
    public float health = 10f;
    public float speed;

    private Player player;
    private Animator anim;

    private void Start()
    {
        player = FindObjectOfType<Player>();
        anim = GetComponent<Animator>();
    }
    // Update is called once per frame
    void Update()
    {
        if (health <= 0) { Destroy(gameObject); }
        transform.position = Vector2.MoveTowards(transform.position, player.transform.position, speed * Time.deltaTime);
        if (speed > 0) { anim.SetBool("IsRun", true); }
    }
    public void TakeDamage(float damage)
    {
        health -= damage;
    }

}
