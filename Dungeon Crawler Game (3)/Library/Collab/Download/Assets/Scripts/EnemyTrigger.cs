using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyTrigger : MonoBehaviour
{
  
    //private Transform cameraMove;
    //public Transform mainCam;
    public GameObject enemyPlayer;
    public GameObject enemyHealth;
    public Text text;
    public GameObject button;
    public Camera[] cams;
    public EnemyTurnbase enemyTurnbase;


    // Start is called before the first frame update
    void Start()
    {
       
        GameObject.Find("BattleSystem").GetComponent<BattleSystem>().enabled = false;
        enemyHealth.SetActive(false);

        text.gameObject.SetActive(false);
        button.SetActive(false);
        cams[1].enabled = false;

    }
    public void OnTriggerEnter2D(Collider2D collider2D)
    {
        if(collider2D.gameObject.CompareTag("Player"))
        {
            
            //GameObject.Find("Main Camera").GetComponent<Follow>().enabled = false;
            cams[0].enabled = false;
            cams[1].enabled = true;
            GameObject.Find("Character").GetComponent<Character>().enabled = false;
            GameObject.Find("Enemy").GetComponent<EnemyTurnbase>().enabled = false;
            GameObject.Find("Turn-basedSystem").GetComponent<TurnBase>().enabled = false;
            GameObject.Find("BattleSystem").GetComponent<BattleSystem>().enabled = true;
            Destroy(enemyPlayer);
            enemyTurnbase.isDead = true;
            enemyHealth.SetActive(true);
            text.gameObject.SetActive(true);
            button.SetActive(true);


            //        // code will go hear for combat system
            //        // player and enemy will be transported to battle arena.
            //        // turn base system will be paused
            //        // ui will be set active 
            //        // camera changes position


        }


    }


    




    //public void OnCollisionEnter(Collision2D collision2D)
    //{
    //    if(collision2D.gameObject.CompareTag("Player"))
    //    {
    //        GameObject.Find("Main Camera").GetComponent<Follow>().enabled = false;
    //        mainCam.transform.position = transform.position;
    //        GameObject.Find("Turn-baseSystem").GetComponent<TurnBase>().enabled = false;
    //        GameObject.Find("BattleSystem").GetComponent<BattleSystem>().enabled = true;
    //        Destroy(enemyPlayer);
    //        enemyHealth.SetActive(true);
    //        playerHealth.SetActive(true);
    //        text.gameObject.SetActive(true);
    //        button.SetActive(true);


    //        // code will go hear for combat system
    //        // player and enemy will be transported to battle arena.
    //        // turn base system will be paused
    //        // ui will be set active 
    //        // camera changes position

    //    }
    //}


}
