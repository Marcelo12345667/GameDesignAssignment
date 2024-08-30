using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using static UnityEditor.Timeline.TimelinePlaybackControls;

public class GameManager : MonoBehaviour
{

    public GameObject gameOverUI;
    public GameObject mountain;
    public GameObject city;
    public bool isMountain;
    // Start is called before the first frame update
    void Start()
    {
        gameOverUI.SetActive(false);
        
    }

    // Update is called once per frame
    void Update()
    {
        BackGroundChangeMountain();
        BackGroundChangeCity();
    }

    public void gameOver()
    {
        gameOverUI.SetActive(true);
    }

    public void restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        


    }

    public void mainMenu()
    {
        SceneManager.LoadScene(2);
        
    }

    public void quit()
    {
        Application.Quit();
    }
    public void OnCollisionEnter2D(Collision2D collision)
    {
        {
            if (collision.gameObject.tag.Equals("flag"))
            {
                isMountain = false;
                
            }
        }
    }
    public void BackGroundChangeMountain()
    {
        if (isMountain == true)
        {
            mountain.SetActive(true);
            city.SetActive(false);
        }
    }
    public void BackGroundChangeCity()
    {

        if (isMountain == false)
        {
            mountain.SetActive(false);
            city.SetActive(true);
        }
    }
}