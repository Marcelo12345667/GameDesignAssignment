using System.Collections;
using System.Collections.Generic;
using UnityEngine;
// put on keys themselfs and make sure player tag is Player
public class KeysDestroy : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Destroy(gameObject);
        }
    }
}
