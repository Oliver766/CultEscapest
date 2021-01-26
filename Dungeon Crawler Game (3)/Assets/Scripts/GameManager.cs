using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public GameObject youWin;// screen
    public GameObject youLoose;// screen
    public GameObject Inventory;// inventory
    public GameObject canvas;// screen
    public Transform Player; //  transform of character
    public Character character; // character
    public Unit playerunit; // player unit
    // Start is called before the first frame update
    public PlayerSave save; // player save 
    public GameObject saved; // gets game ober reference
    void Start()
    {

        youLoose.SetActive(false); // object set false
        youWin.SetActive(false);// object set false
        Inventory.SetActive(false);// object set false
        saved.SetActive(false);// object set false
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.I)) // if key input is I
        {
            Open(); //open function


        }



        if (Input.GetKeyDown(KeyCode.Escape))// if key input is esc
        {
            Pause(); // pausefunction


        }

    }

    public void Open() // open function
    {
        if (Inventory.gameObject.activeInHierarchy == false) // if the inventory is not active in the hierarchy
        {
            Inventory.gameObject.SetActive(true); // set object to true
         

        }
        else
        {
            Inventory.gameObject.SetActive(false); // set object to false


        }
    }


    public void Save()
    {
        save.Save();// runs save function
        StartCoroutine(Saving()); // player coroutine

    }

   



    public void wellDone() // game one function
    {
        youWin.SetActive(true); // set object to true
        Time.timeScale = 0; // time scale equals 0



    }

    public void youLost() // game over function
    {
        youLoose.SetActive(true);// set object to true
        Time.timeScale = 0; // time scale equals 0



    }


  


    public void MainMenu() // mainmenu function
    {
        SceneManager.LoadScene("MainMenu");//loading menu


    }

    public void Replay() // replay function
    {
        SceneManager.LoadScene("CultEscapest"); // load game
        Time.timeScale = 1;// game timscale set to 1


    }

    public void OnApplicationQuit() //quit function
    {
        Application.Quit(); // quit game

    }


    public void Pause() // pause function
    {
        if (canvas.gameObject.activeInHierarchy == false)// if the pausemenu is not active in the hierarchy
        {
            canvas.gameObject.SetActive(true); // set object to true
            Time.timeScale = 0;// time scale equals 0
            Player.GetComponent<Character>().enabled = false; // player movement is disabled

        }
        else
        {
            canvas.gameObject.SetActive(false);// set object to false
            Time.timeScale = 1; // game timscale set to 1
            Player.GetComponent<Character>().enabled = true;// player movement is enabled

        }
    }

    public IEnumerator Saving()
    {
        saved.SetActive(true); // sets game object to true
        yield return new WaitForSeconds(0.5f); // waits half a secon
        saved.SetActive(false); // sets game object to false


    }

}

