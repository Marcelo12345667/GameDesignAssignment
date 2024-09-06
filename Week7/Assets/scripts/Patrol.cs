using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Patrol : MonoBehaviour
{
    //speed variable
    public float speed;
    //boolean wheather moving right is true
    private bool movingRight = true;
   
    public Transform groundDetection;
    public LayerMask floor;
    // runs every frame
    void FixedUpdate()
    {
        LayerMask floor = LayerMask.GetMask("floor");
        
    }
    void Update()
    {
        transform.Translate(Vector2.right * speed * Time.deltaTime);
        //creates a raycast that shoots towards the ground infront of the player to check weather there is ground underneath
        RaycastHit2D groundInfo = Physics2D.Raycast(groundDetection.position, Vector2.down, 2f, layerMask:floor);
        //if there is no ground it activates this if statement
        if(groundInfo.collider == false)
        {
            //if the enemy is moving right while there is no ground in front of itthis activates turning the enemy around
            if(movingRight == true)
            {
                //This changes the rotation of the enemy from right to left using postions
                transform.eulerAngles = new Vector3(0, -180, 0);
                //Changes moving right = true to false which means its not turning right
                movingRight = false;

            }
            //if the enemy is not moving right this code plays instead
            else
            {
                //Same as the previous code except it flips from left to right
                transform.eulerAngles = new Vector3(0, 0, 0);
                //Same as previous code above except it changes to the player is moving right not left
                movingRight = true;
            }
        }

    }


}
