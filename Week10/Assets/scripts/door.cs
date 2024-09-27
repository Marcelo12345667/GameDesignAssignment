using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class door : MonoBehaviour
{
    public GameObject player;
    private PlayerController playerController;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        playerController = player.GetComponent<PlayerController>();
        if (playerController.collectables == 2)
        {
            Destroy(gameObject);
        }
    }
}
