using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathBox : MonoBehaviour
{
    //makes life variable
    public int health;
    //regenerate health when you die
    public int healthRegen;
    // Start is called before the first frame update
    public Vector3 respawnPosition;


    void Update()
    {
        life();
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
