using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public enum BattleState // list of battle states
{
    start,
    playerTurn,
    EnemyTurn,
    Won,
    Lost,

}

public class BattleSystem : MonoBehaviour
{
    public BattleState state; // battle states
    public GameObject player; // player  
    public GameObject enemy; // enemy

    
  

    Unit playerUnit; // player for unit code
    Unit enemyUnit; // enemy for unit code

   

   
   
    public BattleHud enemyHud; // enemy hud

    public BattleHud playerHud; // playyer hud

    public Text dialogueText; // text object
    public GameManager manager; // game manager
    public Camera[] cam; // cameras
    

    public GameObject pHud; // player hud game object
    public GameObject eHud; // enemy hud game object
    public Text text; //  text object
    public GameObject Abutton; // action buttons

    public int md = 30; // min damage
    public int mad = 0;  // max damage
    public Image hitPlayer; // player hurt image
    public Image hitEnemy; // enemy hurt image
    public Image regen; // regen image
    public GameObject inventory; // inventory








    // Start is called before the first frame update
    void Start()
    {

       
       
            state = BattleState.start; // set state to start
            StartCoroutine(SetUpBattle()); // start coroutine


    }

    public void Update()
    {
       
        
       
        if (hitPlayer != null) // hit screen function
        {

            if (hitPlayer.GetComponent<Image>().color.a > 0) // gets image component
            {

                var color = hitPlayer.GetComponent<Image>().color;// gets image component

                color.a -= 0.01f; // screen flashes

                hitPlayer.GetComponent<Image>().color = color;// gets image component

            }

        }
        if (hitEnemy != null) // hit screen function
        {

            if (hitEnemy.GetComponent<Image>().color.a > 0) // gets image component
            {

                var color = hitEnemy.GetComponent<Image>().color;// gets image component

                color.a -= 0.01f; // screen flashes

                hitEnemy.GetComponent<Image>().color = color;// gets image component

            }

        }
        if (regen != null) // hit screen function
        {

            if (regen.GetComponent<Image>().color.a > 0) // gets image component
            {

                var color = regen.GetComponent<Image>().color;// gets image component

                color.a -= 0.01f; // screen flashes

                regen.GetComponent<Image>().color = color;// gets image component

            }

        }


    }


    IEnumerator SetUpBattle()
    {
         GameObject playerGo =  Instantiate(player, new Vector3 (114,30), Quaternion.identity); //  spawn player
         playerUnit = playerGo.GetComponent<Unit>(); // gets unit component from scripts
        GameObject enemyGo =   Instantiate(enemy, new Vector3(120,30), Quaternion.identity); // spawn enemy
        enemyUnit = enemyGo.GetComponent<Unit>();// gets unit component from scripts
        playerHud.SetHP(playerUnit.currentHP); // sets current health
        playerHud.SetHud(playerUnit); // sets player hud
        enemyHud.SetHP(enemyUnit.currentHP  = 100); // sets enemy health
        enemyHud.SetHud(enemyUnit); // sets eenmy hud

      
        dialogueText.text = "Welcome to the Cult Arena"; //  plays  text

        yield return  new WaitForSeconds(4f);

        dialogueText.text = "Your HP has Been Restored!"; // health restored


        yield return new WaitForSeconds(5f);  // wait for 2 seconds

        state = BattleState.playerTurn; //  set state to player turn
        StartCoroutine(PlayerTurn()); //player turn


    }

    IEnumerator PlayerLightAttack()
    {

       bool isDead  =  enemyUnit.TakeDamage(playerUnit.damage ); // bool is dead equals enemy unit . takes damage, enemy takes damage

       
        // Damage the enemy 
        enemyHud.SetHP(enemyUnit.currentHP);// sets healths
        


        dialogueText.text = "The attack is sucessful!"; // attack dialogue
        yield return new WaitForSeconds(2f); // wait for 2 seconds
       

        if (isDead) // if is dead
        {

            state = BattleState.Won; // set state to won
            EndBattleFunction(); // end battle
        }
        else
        {
            state = BattleState.EnemyTurn; // set state to enemy turn
            StartCoroutine(enemyTurn()); // start coroutine

        }
    }

    IEnumerator PlayerHeavyAttack()
    {


        bool isDead = enemyUnit.TakeDamage(playerUnit.damage + 10 );// bool is dead equals enemy unit . takes damage, enemy takes damage


        // Damage the enemy 
        enemyHud.SetHP(enemyUnit.currentHP);// sets healths


        dialogueText.text = "The attack is sucessful!";// attack dialogue
        yield return new WaitForSeconds(2f);// wait for 2 seconds


        if (isDead)// if is dead
        {

            state = BattleState.Won;// set state to won
            EndBattleFunction();// end battle
        }
        else
        {
            state = BattleState.EnemyTurn; // set state to enemy turn

            StartCoroutine(enemyTurn());// start coroutine

        }
    }

   

    IEnumerator enemyTurn()
    {
        gotHurt(); // got hurt screen
       int ed = Random.Range(md, mad); // random range
        dialogueText.text =  "Enemy Attacks!"; // attack dialogue


        yield return new WaitForSeconds(1f);// wait for 1 seconds


        bool isDead =  playerUnit.TakeDamage(enemyUnit.damage + ed);// bool is dead equals enemy unit . takes damage, player takes damage

        playerHud.SetHP(playerUnit.currentHP);// sets healths
        yield return new WaitForSeconds(1f);// wait for 1 seconds
        if (isDead)
        {
            state = BattleState.Lost;// set state to lost
            manager.youLost(); //  you lost screen appears
        }
        else
        {
            state = BattleState.playerTurn;// set state to enemy turn

            StartCoroutine(PlayerTurn()); //player turn

        }

    }

 

    IEnumerator Regen()
    {
        health(); // health screen appears
        playerUnit.Heal(10); // heals player by 10

        playerHud.SetHP(playerUnit.currentHP);// sets healths
        dialogueText.text =  "Heal!"; // heal text

        yield return new WaitForSeconds(2f);// wait for 2 seconds
        
        state = BattleState.EnemyTurn; // set state to enemy turn
        StartCoroutine(enemyTurn());// start coroutine

    }



    public void EndBattleFunction()
      {
        if (state == BattleState.Won)
        {

            dialogueText.text = "You won the battle!"; // text appears
            Destroy(enemyUnit); // destroy enemy unit
            Destroy(playerUnit); // destroy player unit
            state = BattleState.start; // set state back to start
            Debug.Log(state);
            StartCoroutine(SetUpBattle()); // start coroutine
            

            text.gameObject.SetActive(false); // set text object false
            pHud.SetActive(false); // set hud false
            eHud.SetActive(false);// set hud false
            Abutton.SetActive(false); // set buton false
            GameObject.Find("Turn-basedSystem").GetComponent<TurnBase>().enabled = true; // disable turn base system component
            GameObject.Find("BattleSystem").GetComponent<BattleSystem>().enabled = false; // disable battle system component
            cam[0].enabled = false; // set camera false
            cam[1].enabled = true; // set camera true
           
            GameObject.Find("Main Camera").GetComponent<Follow>().enabled = true; // enable follow camer component on main camera
            GameObject.Find("Character").GetComponent<Character>().enabled = true; // enable enemy component
            GameObject.Find("Enemy1").GetComponent<EnemyTurnbase>().enabled = true;// enable enemy component
            GameObject.Find("Enemy2").GetComponent<EnemyTurnbase>().enabled = true;// enable enemy component
            GameObject.Find("Enemy3").GetComponent<EnemyTurnbase>().enabled = true;// enable enemy component
            GameObject.Find("Enemy4").GetComponent<EnemyTurnbase>().enabled = true;// enable enemy component
            GameObject.Find("Enemy5").GetComponent<EnemyTurnbase>().enabled = true;// enable enemy component
            GameObject.Find("Enemy6").GetComponent<EnemyTurnbase>().enabled = true;// enable enemy component
            GameObject.Find("Enemy7").GetComponent<EnemyTurnbase>().enabled = true;// enable enemy component
            GameObject.Find("Enemy8").GetComponent<EnemyTurnbase>().enabled = true;// enable enemy component
            GameObject.Find("Enemy9").GetComponent<EnemyTurnbase>().enabled = true;// enable enemy component
            GameObject.Find("Enemy10").GetComponent<EnemyTurnbase>().enabled = true;// enable enemy component
            GameObject.Find("Enemy11").GetComponent<EnemyTurnbase>().enabled = true;// enable enemy component
            GameObject.Find("Enemy12").GetComponent<EnemyTurnbase>().enabled = true;// enable enemy component
            GameObject.Find("Enemy13").GetComponent<EnemyTurnbase>().enabled = true;// enable enemy component
            StartCoroutine(SetUpBattle()); // start coroutine

        }
        else if (state == BattleState.Lost) // set state to lost
        {
            manager.youLost(); // you lost screen appears
        }

      }

    public IEnumerator PlayerTurn() 
    {
       
        yield return new WaitForSeconds(1f);// wait for 2 seconds
        dialogueText.text = "Ready To fight"; // player text every time its players turn
       
       

    }
 

    public void OnAttackButton()
    {

        if(state != BattleState.playerTurn) //  if state isnt set to player turn
        
            return; // return  state
       
        
         StartCoroutine(PlayerLightAttack()); // start coroutine
        playerhurt(); // player hurt screen is set active

    }


    public void OnAttackHeavyButton()
    {
        if (state != BattleState.playerTurn)//  if state isnt set to player turn
            return;// return  state

        StartCoroutine(PlayerHeavyAttack());// start coroutine
        playerhurt(); // player hurt screen is set active

    }
    public void Heal()
    {
        if (state != BattleState.playerTurn)
            return;// return  state


        StartCoroutine(Regen());// start coroutine
        health(); // player hurt screen is set active

    }



    public void gotHurt()
    {

        var color = hitPlayer.GetComponent<Image>().color; // gets image component of hit player image
        color.a = 0.8f; //  colour equals 0.08f

        hitPlayer.GetComponent<Image>().color = color; // hit player image component image . color equals the color

    }

    public void playerhurt()
    {

        var color = hitEnemy.GetComponent<Image>().color;// gets image component of hit enemy image
        color.a = 0.8f;//  colour equals 0.08f

        hitEnemy.GetComponent<Image>().color = color; // hit enemy image component image . color equals the color

    }

    public void health()
    {


        var color = regen.GetComponent<Image>().color;// gets image component of regen image
        color.a = 0.8f;//  colour equals 0.08f

        regen.GetComponent<Image>().color = color;// regen image component image . color equals the color

    }



}
