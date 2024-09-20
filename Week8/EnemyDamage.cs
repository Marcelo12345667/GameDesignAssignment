using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
//Put Script on Player and set enemy tags to Death
public class EnemyDamage : MonoBehaviour
{


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Death"))
        {
            Destroy(gameObject);

        }

    }
}
