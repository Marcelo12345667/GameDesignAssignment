using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Spring : MonoBehaviour
{
    //public Animator anim;
    public float jumpforce = 20;
    // Start is called before the first frame update
    void Start()
    {
        ///anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {

    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        //if (collision.transform.CompareTag("Player"))
        //{
            ///anim.SetBool("onSpring", true);

        //}
        if (collision.relativeVelocity.y <= 0f)
        {
            Rigidbody2D rb = collision.collider.GetComponent<Rigidbody2D>();
            if (rb != null)
            {
                Vector2 velocity = rb.velocity;
                velocity.y = jumpforce;
                rb.velocity = velocity;
            }
        }
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        ///if (collision.transform.CompareTag("Player"))
        //{
            ///anim.SetBool("onSpring", false);
        //}

    }
}
