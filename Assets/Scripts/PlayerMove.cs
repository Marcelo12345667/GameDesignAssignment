//Things needed for the character
//RigidBody2d
//Player itself (can be anything)
//BoxColider2d for both player and platform
//Then you need to create a PhysicsMaterial2D (not in addConponent in Assets like where you create scripts and scenes) Open it and set friction to zero in this way the character doesn't get stuck to walls
using System.Collections;
using System.Collections.Generic;
using Unity.Collections;
//using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Animations;
using UnityEngine.Purchasing;

public class PlayerMove : MonoBehaviour
{
    public SpriteRenderer sprite;
    private float dirX;
    // Speed variable
    public float speed;
    //JumpForce variable
    public float jumpForce;
    //Deturmines what button is pressed
    private float moveInput;
    //Rigidbody variable
    private Rigidbody2D rb;
    //Boolean wheather facing left or right
    private bool facingRight = true;
    //Checks if player is grounded
    private bool isGrounded;
    private Animator animator;
    public Transform groundCheck;
    //checks Radius under the players feat from isGrounded
    public float checkRadius;
    //Creates a LayerMask
    public LayerMask whatIsGround;
    //gives hidden extrajumps non changeable
    private int extraJumps;
    //public extraJumpsvalue changeable
    public int extraJumpsValue;
    //creates a starting position
    public Vector3 startingPosition;
    //uses function on start

    public coinManager Cm;
    void Start()
    {
        extraJumps = extraJumpsValue;
        //Get the RigidBody component from Player
        rb = GetComponent<Rigidbody2D>();
        startPosition();
        animator = GetComponent<Animator>();


    }
    //Checks every Frame
    void Update()
    {

        if (isGrounded == true)
        {
            extraJumps = extraJumpsValue;
        }
        //make it so if UpArrow is presses the function in the box will occur and the function will only work if your 'Extra jumps' are greater than 0 if it is not greater that 0 than it moves on to the next boolean
        if (Input.GetKeyDown(KeyCode.UpArrow) && extraJumps > 0)
        {
            animator.SetBool("Jump", true);
            //calls rigidbody gives it the ability to move up and is multiplied by jumpforce
            rb.velocity = Vector2.up * jumpForce;
            //Decreases ExtraJumps
            extraJumps--;
        }
        // if there are no extrajumps you cant jump however it allows you to jump again if your grounded
        else if (Input.GetKeyDown(KeyCode.UpArrow) && extraJumps == 0 && isGrounded == true)
        {
            rb.velocity = Vector2.up * jumpForce;
        }
        Flip();
       
        animator.SetBool("isGrounded", isGrounded);
        animator.SetBool("IsInAir", !isGrounded);
        animator.SetBool("isMoving", moveInput != 0);
        animator.SetBool("Jump", !isGrounded);
        animator.SetFloat("yVelocity", rb.velocity.y);
    }
    // Rather than update that updates every frame FixedUpdate is always consitent with a defult of 50 frames per seccond.
    private void FixedUpdate()
    {
        dirX = Input.GetAxis("Horizontal");
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, checkRadius, whatIsGround);

        //This gives moveInput the input left and right allowing to get the direction(if that makes sense)
        moveInput = Input.GetAxisRaw("Horizontal");
        //calls rigidbody and gives it a move input, speed and movement depending on the axis
        rb.velocity = new Vector2(dirX = moveInput * speed, rb.velocity.y);
        

        //if facing right is false and is moving in a negative direction it calls flip
        if (facingRight == false && moveInput > 0)
        {
            //calls flip
            //Flip();
        }
        //if facing right is true and is moving in a possitive direction calls flip as well
        else if (facingRight == true && moveInput < 0)
        {
            //calls flip
            //Flip();
        }



    }
    public void startPosition()
    {

        transform.position = startingPosition;
    }
    //creates Flip function
    void Flip()
    {

        if (dirX > 0f)
        {
            sprite.flipX = false;

        }
        if (dirX < 0f)
        {
            sprite.flipX = true;

        }

        // makes it if facing right is true then it is false and if facing right is false then it is true (a bit convoluded)
        //facingRight = !facingRight;
        // makes Scaler equal to to the scale of parent object in order to change the local scale next
        //Vector3 Scaler = transform.localScale;
        // if scale is like 4 for example then * -1 would = -4 if the number is -4 then * -1 it would = 4
        //Scaler.x *= -1;
        //after the math Scaler transforms back into localscale changing the way the player is facing form whether the position is facing positive or negative
        //transform.localScale = Scaler;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("coin"))
        {
            Destroy(other.gameObject);
            Cm.coinCount++;
        }
    }

}