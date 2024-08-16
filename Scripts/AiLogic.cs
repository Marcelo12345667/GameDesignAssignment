using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AiLogic : MonoBehaviour
{
       public Transform key;
       public MoveDoor door;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
       {
           if (door.isOpen == false && != null)
              {
                 _agent.destination = key.position;
              }
       }

    private void OnTriggerEnter(Collider other)
       {
           if (key == other.gameObject)
              {
                 door.unlockDoor = true;

                 Destroy(other.gameObject);
              }
       }
}
