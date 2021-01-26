using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyTrigger : MonoBehaviour
{
  
    //private Transform cameraMove;
    //public Transform mainCam;
    public GameObject enemyPlayer; // enemy player
    public BattleHud enemyHud; // enemy hud
    public BattleHud playerHud; // player hud
    public Text text; // text oject
    public GameObject button; // button object
    public Camera[] cams; // cameras
    public EnemyTurnbase enemyTurnbase; // enemy turn base
    public BattleSystem system; // battle ssytem object
    public GameObject inventory; // invenotry game object
    //public BattleHud enemyHud;
    
    Unit enemyUnit; // enemy unit from unit script



    // Start is called before the first frame update
    void Start()
    {

        GameObject.Find("BattleSystem").GetComponent<BattleSystem>().enabled = false; // disabled battle system
        enemyHud.gameObject.SetActive(false); // sets object to not active
        playerHud.gameObject.SetActive(false);// sets object to not active


        text.gameObject.SetActive(false);// sets object to not active
        button.SetActive(false);// sets object to not active
        cams[1].enabled = false;// sets camera to not active

    }
    public void OnTriggerEnter2D(Collider2D collider2D)
    {
        
        

        if (collider2D.gameObject.CompareTag("Player")) // if object collides  with player with player tag
        {
            
            enemyHud.gameObject.SetActive(true); // object set to active
            text.gameObject.SetActive(true);// object set to active
            button.SetActive(true);// object set to active
            playerHud.gameObject.SetActive(true);// object set to active
            GameObject.Find("Main Camera").GetComponent<Follow>().enabled = false; // follow component is disabled
            cams[0].enabled = false;// sets camera to not active
            cams[1].enabled = true;// sets camera to  active
            enemyPlayer.SetActive(false);// object set to active
            GameObject.Find("BattleSystem").GetComponent<BattleSystem>().enabled = true; // enable battle system
            GameObject.Find("Character").GetComponent<Character>().enabled = false;// disable character
            GameObject.Find("Turn-basedSystem").GetComponent<TurnBase>().enabled = false;// disable turnbased system
            GameObject.Find("Enemy1").GetComponent<EnemyTurnbase>().enabled = false; // disable enemy
            GameObject.Find("Enemy2").GetComponent<EnemyTurnbase>().enabled = false;// disable enemy
            GameObject.Find("Enemy3").GetComponent<EnemyTurnbase>().enabled = false;// disable enemy
            GameObject.Find("Enemy4").GetComponent<EnemyTurnbase>().enabled = false;// disable enemy
            GameObject.Find("Enemy5").GetComponent<EnemyTurnbase>().enabled = false;// disable enemy
            GameObject.Find("Enemy6").GetComponent<EnemyTurnbase>().enabled = false;// disable enemy
            GameObject.Find("Enemy7").GetComponent<EnemyTurnbase>().enabled = false;// disable enemy
            GameObject.Find("Enemy8").GetComponent<EnemyTurnbase>().enabled = false;// disable enemy
            GameObject.Find("Enemy9").GetComponent<EnemyTurnbase>().enabled = false;// disable enemy
            GameObject.Find("Enemy10").GetComponent<EnemyTurnbase>().enabled = false;// disable enemy
            GameObject.Find("Enemy11").GetComponent<EnemyTurnbase>().enabled = false;// disable enemy
            GameObject.Find("Enemy12").GetComponent<EnemyTurnbase>().enabled = false;// disable enemy
            GameObject.Find("Enemy13").GetComponent<EnemyTurnbase>().enabled = false;// disable enemy






        }


    }


    




    


}
