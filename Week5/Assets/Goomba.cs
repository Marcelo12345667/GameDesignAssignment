using System.Collections;
using System.Collections.Generic;

using UnityEngine;

public class Hitstomp : MonoBehaviour
{
    //makes life variable
    public int health;
    //regenerate health when you die
    public int healthRegen;
    // Start is called before the first frame update
    public Vector3 respawnPosition;

    public float bounce;
    public Rigidbody2D rb2D;

    void Update()
    {
        life();
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Enemy"))
        {
            Destroy(other.gameObject);
            rb2D.velocity = new Vector2(rb2D.velocity.x, bounce);
        }
    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag.Equals("Enemy"))
        {
            health -= 1000;

        }
    }
    void life()
    {
        if (health == 0)
        {

            transform.position = respawnPosition;
            health = healthRegen;
        }
    }

}
