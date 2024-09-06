using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerHealth : MonoBehaviour
{
    //makes life variable
    public int health;
    //regenerate health when you die
    public int healthRegen;
    // Start is called before the first frame update
    public Vector3 respawnPosition;


    public HealthBar healthBar;

    private bool isDead;

    public GameManager gameDemon;


    void Update()
    {
        life();

    }
    void TakeDamage(int damage)
    {
        health -= damage;

        healthBar.SetHealth(health);
        if (health <= 0)
        {
            healthBar.SetHealth(healthRegen);
        }
    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag.Equals("Enemy"))
        {
            TakeDamage(1);

        }
        if (collision.gameObject.tag.Equals("DeathBox"))
        {
            TakeDamage(1000000);
        }
        if (collision.gameObject.tag.Equals("flag"))
        {
            health = healthRegen;
        }
    }
    void life()
    {
        if (health <= 0 && !isDead)
        {
            isDead = true;
            gameDemon.gameOver();
            health = healthRegen;

        }

    }
}