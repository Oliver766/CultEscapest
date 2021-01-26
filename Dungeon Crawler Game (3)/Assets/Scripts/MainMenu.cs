using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{

    public GameObject controls; // gets controls screen
    public GameObject credits; // gets credits creen
    public GameObject HowToPlay; // gets how to play screen;
  
    public void Start()
    {
        credits.SetActive(false); // sets credits to false
        controls.SetActive(false); // sest controls to false
        HowToPlay.SetActive(false); // set gameobject to false
    }


    public void Play()
    {
        SceneManager.LoadScene("CultEscapest"); //load game

        Time.timeScale = 1; // set time scale to 1

    }



    public void howToPlay()
    {

        HowToPlay.SetActive(true); // set gameobject to true

    }


    public void Quit()
    {

        Application.Quit(); // quit the game

    }
 

    public void Controls()
    {


        controls.SetActive(true); // set the control screen to true

    }

    public void creditScene()
    {

        credits.SetActive(true); // set the credits screen to true

    }

    public void Back()
    {

        credits.SetActive(false);  // sets the credits to false
        controls.SetActive(false); // sets the controls to false
        HowToPlay.SetActive(false);// sets the How To Play to false

    }
    


  


}
