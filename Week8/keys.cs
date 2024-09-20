using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//put script on player and make sure score manager is loaded
public class keys : MonoBehaviour
{

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("keys"))
        {
            FindObjectOfType<ScoreManager>().AddKeys();

        }
        
    }
}
