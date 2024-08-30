using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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

    [SerializeField] private int numJumps;
    [SerializeField] private int jumpForce;
    private int jumpsLeft;
    private float jumpTimer;
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
            jumpsLeft = numJumps;
        }

        jumpTimer += Time.fixedDeltaTime;
    }

    // Update is called once per frame
    void Update()
    {
        float x = Input.GetAxis("Horizontal");

        if(useTransformMovement == false)
        {
            rb.velocity = new Vector3(x * moveSpeed, rb.velocity.y, 0);
        }
        else
        {
            transform.position = new Vector3(transform.position.x + x * Time.deltaTime * moveSpeed, 
            transform.position.y, transform.position.z);
        }
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (jumpsLeft > 0)
            {
                rb.velocity = Vector3.zero;
                rb.AddForce(Vector3.up * jumpForce);
                jumpsLeft--;
                jumpTimer = 0;
            }
        }
        Flip();

    }

    public void SetMoveSpeed(int _moveSpeed)
    {
        moveSpeed = _moveSpeed;
    }
    private void Flip()
    {
        if (isFacingRight && horizontal < 0f || !isFacingRight && horizontal > 0f)
        {
            isFacingRight = !isFacingRight;
            Vector3 localScale = transform.localScale;
            localScale.x *= -1f;
            transform.localScale = localScale;

        }
    }
}
