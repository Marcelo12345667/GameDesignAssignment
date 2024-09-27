using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Spring : MonoBehaviour
{
    //public Animator anim;
    public float jumpforce = 20;
    public Animator springo;
    public AudioSource clunk;
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.relativeVelocity.y <= 0f)
        {
            Rigidbody2D rb = collision.collider.GetComponent<Rigidbody2D>();
            if (rb != null)
            {
                springo.SetBool("isplayeron", true);
                Vector2 velocity = rb.velocity;
                velocity.y = jumpforce;
                rb.velocity = velocity;
                clunk.Play();
            }
        }
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        springo.SetBool("isplayeron", false);

    }
}
