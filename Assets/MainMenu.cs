using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public void PlayGame()
    {
        //main menu is scene 0
        //loads game. Game is scene 1
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }


    public void quitGame()
    {
        Application.Quit();
    }

    public void replayGame()
    {
        //Game Comeplete menu screen is scene 2
        //loads the menu as that's set to 0
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 2);
    }


}
