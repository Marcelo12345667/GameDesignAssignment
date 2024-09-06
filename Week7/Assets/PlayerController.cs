using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    private Rigidbody2D rb;
    [SerializeField] private int moveSpeed;

    public bool useTransformMovement;

    private float horizontal;
    private float speed = 8f;
    private float jumpingPower = 16f;
    private bool isFacingRight = true;

    [SerializeField] private bool isGrounded;
    [SerializeField] private Transform groundRayTransform;
    [SerializeField] private LayerMask groundLayer;
    public float health;
    [SerializeField] private int numJumps;
    [SerializeField] private int jumpForce;
    private int jumpsLeft;
    private float jumpTimer;
    public SpriteRenderer sprite;

    public Animator animator;

    public AudioSource jump;
    public AudioSource land;
    // Start is called before the first frame update
    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        isGrounded = Physics2D.Linecast(transform.position, groundRayTransform.position, groundLayer);

        if (isGrounded == true && jumpTimer >= 0.5f)
        {
            animator.SetBool("isjumping", false);
            jumpsLeft = numJumps;
            
            
        }

        jumpTimer += Time.fixedDeltaTime;
    }

    // Update is called once per frame
    void Update()
    {
        float x = Input.GetAxis("Horizontal");
        //Debug.Log(x);
        //if (isGrounded == true)
        //{
        //animator.SetBool("isjumping", false);
        //}

        if (x < 0)
        {
            sprite.flipX = true;

        }
        if (x > 0)
        {
            sprite.flipX = false;

        }

        if (useTransformMovement == false)
        {
            rb.velocity = new Vector3(x * moveSpeed, rb.velocity.y, 0);
        }
        else
        {
            
            transform.position = new Vector3(transform.position.x + x * Time.deltaTime * moveSpeed, 
            transform.position.y, transform.position.z);
            animator.SetFloat("speed", Mathf.Abs(x));
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {

            
            if (jumpsLeft > 0 && isGrounded == true)
            {
                jump.Play();
                rb.velocity = Vector3.zero;
                rb.AddForce(Vector3.up * jumpForce);
                jumpsLeft--;
                jumpTimer = 0;
            }
        }
        if (isGrounded == false)
        {
            animator.SetBool("isjumping", true);
        }
        Death();
    }

    public void SetMoveSpeed(int _moveSpeed)
    {
        moveSpeed = _moveSpeed;
    }   
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            health -= 1;
        }
    }
    public void Death()
    {
        if (health <= 0)
        {
            Destroy(gameObject);
        }
    }
}
