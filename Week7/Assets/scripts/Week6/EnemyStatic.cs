using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class EnemyStatic : MonoBehaviour
{
    private float health;
    PlayerMain playerMain;
    [SerializeField] GameObject player;
    // Start is called before the first frame update
    void Awake()
    {
        playerMain = player.GetComponent<PlayerMain>();
        playerMain.health = 5;
    }
    void Start()
    {
    
   
    }

    // Update is called once per frame
    void Update()
    {

    }
   
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            playerMain.health = playerMain.health - 1;
        }
    }
}
