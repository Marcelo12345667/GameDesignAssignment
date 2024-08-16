using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveDoor : MonoBehaviour
{
       public float speed = 5f;


       public bool isOpen = false;

       public bool unlockDoor = false;


       Vector3 _closedPosition = Vector3.zero;

       Vector3 _openPosition = Vector3.zero;

    // Start is called before the first frame update
    void Start()
       {
           _closedPosition = transform.position;

           _openPosition = transform.position + new Vector3(0f, -3f, 0f);
       }

    // Update is called once per frame
    void Update()
       {
           if (unlockDoor == true)
              {
                 transform.position = Vector3.MoveTowards(transform.position, _openPosition, speed * Time.deltaTime);
              }


           if(transform.position == _openPosition)
              {
                 isOpen = true;
              }
       }
}
