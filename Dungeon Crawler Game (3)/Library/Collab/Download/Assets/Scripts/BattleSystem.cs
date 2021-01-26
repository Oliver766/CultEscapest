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

   

   
   
    public BattleHud enemyHud;

    public BattleHud playerHud;

    public Text dialogueText;
    public GameManager manager;
    public Camera[] cam;
    

    public GameObject pHud;
    public GameObject eHud;
    public Text text;
    public GameObject Abutton;

    public int md = 30;
    public int mad = 0;
    public Image hitPlayer;
    public Image hitEnemy;
    public Image regen;








    // Start is called before the first frame update
    void Start()
    {

      

           
            

       
            state = BattleState.start;
            StartCoroutine(SetUpBattle());

        

       

     


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
        
       
        GameObject playerGo =  Instantiate(player, new Vector3 (114,30), Quaternion.identity);
         playerUnit = playerGo.GetComponent<Unit>();
      GameObject enemyGo =   Instantiate(enemy, new Vector3(120,30), Quaternion.identity);
        enemyUnit = enemyGo.GetComponent<Unit>();
        playerHud.SetHP(playerUnit.currentHP);
        enemyHud.SetHP(enemyUnit.currentHP  = 100);
        playerHud.SetHP(playerUnit.currentHP);
        playerHud.SetHud(playerUnit);
        enemyHud.SetHud(enemyUnit);

        dialogueText.text = "Welcome to the Cult Arena";

    




        yield return new WaitForSeconds(2f);
        state = BattleState.playerTurn;
        PlayerTurn();



    }

    IEnumerator PlayerLightAttack()
    {

       bool isDead  =  enemyUnit.TakeDamage(playerUnit.damage );

       
        // Damage the enemy 
        enemyHud.SetHP(enemyUnit.currentHP);
        


        dialogueText.text = "the attack is sucessful!";
        yield return new WaitForSeconds(2f);
       

        if (isDead)
        {

            state = BattleState.Won;
            EndBattleFunction();
        }
        else
        {
            state = BattleState.EnemyTurn;
            StartCoroutine(enemyTurn());

        }
    }

    IEnumerator PlayerHeavyAttack()
    {


        bool isDead = enemyUnit.TakeDamage(playerUnit.damage + 10 );
       

        // Damage the enemy 
        enemyHud.SetHP(enemyUnit.currentHP);
        

        dialogueText.text = "the attack is sucessful!";
        yield return new WaitForSeconds(2f);
       

        if (isDead)
        {

            state = BattleState.Won;
            EndBattleFunction();
        }
        else
        {
            state = BattleState.EnemyTurn;
           
            StartCoroutine(enemyTurn());

        }
    }

   

    IEnumerator enemyTurn()
    {
        gotHurt();
       int ed = Random.Range(md, mad);
        dialogueText.text = enemyUnit.unitName + "EnemyAttacks!";
        

        yield return new WaitForSeconds(1f);
      

        bool isDead =  playerUnit.TakeDamage(enemyUnit.damage + ed);

        playerHud.SetHP(playerUnit.currentHP);
        yield return new WaitForSeconds(1f);
        if(isDead)
        {
            state = BattleState.Lost;
            manager.youLost();
        }
        else
        {
            state = BattleState.playerTurn;

            PlayerTurn();

        }

    }

 

    IEnumerator Regen()
    {
        healtth();
        playerUnit.Heal(10);

        playerHud.SetHP(playerUnit.currentHP);
        dialogueText.text = enemyUnit.unitName + "Heal!";


        yield return new WaitForSeconds(1f);

       

        yield return new WaitForSeconds(2f);
        // regens player through armour on screen
        state = BattleState.EnemyTurn;
        

    }



    public void EndBattleFunction()
      {
        if (state == BattleState.Won)
        {

            dialogueText.text = "You won the battle!";
            state = BattleState.start;
            Debug.Log(state);
            StartCoroutine(SetUpBattle());

            text.gameObject.SetActive(false);
            pHud.SetActive(false);
            eHud.SetActive(false);
            Abutton.SetActive(false);
            GameObject.Find("Turn-basedSystem").GetComponent<TurnBase>().enabled = true;
            GameObject.Find("BattleSystem").GetComponent<BattleSystem>().enabled = false;
            cam[0].enabled = false;
            cam[1].enabled = true;
           
            GameObject.Find("Main Camera").GetComponent<Follow>().enabled = true;
            GameObject.Find("Character").GetComponent<Character>().enabled = true;
            GameObject.Find("Enemy1").GetComponent<EnemyTurnbase>().enabled = true;
            GameObject.Find("Enemy2").GetComponent<EnemyTurnbase>().enabled = true;
            GameObject.Find("Enemy3").GetComponent<EnemyTurnbase>().enabled = true;
            GameObject.Find("Enemy4").GetComponent<EnemyTurnbase>().enabled = true;
            GameObject.Find("Enemy5").GetComponent<EnemyTurnbase>().enabled = true;
            GameObject.Find("Enemy6").GetComponent<EnemyTurnbase>().enabled = true;
            GameObject.Find("Enemy7").GetComponent<EnemyTurnbase>().enabled = true;
            GameObject.Find("Enemy8").GetComponent<EnemyTurnbase>().enabled = true;
            GameObject.Find("Enemy9").GetComponent<EnemyTurnbase>().enabled = true;
            GameObject.Find("Enemy10").GetComponent<EnemyTurnbase>().enabled = true;

          
            
            
            


        }
        else if (state == BattleState.Lost)
        {
            manager.youLost();
        }

      }

    public void PlayerTurn()
    {

        dialogueText.text = "Ready To fight";

    }

    public void OnAttackButton()
    {

        if(state != BattleState.playerTurn)
        
            return;
       
        
         StartCoroutine(PlayerLightAttack());
        playerhurt();

    }


    public void OnAttackHeavyButton()
    {
        if (state != BattleState.playerTurn)
            return;

        StartCoroutine(PlayerHeavyAttack());
        playerhurt();

    }
    public void Heal()
    {
        if (state != BattleState.playerTurn)
            return;

        StartCoroutine(Regen());
        healtth();

    }



    public void gotHurt()
    {

        var color = hitPlayer.GetComponent<Image>().color;
        color.a = 0.8f;

        hitPlayer.GetComponent<Image>().color = color;

    }

    public void playerhurt()
    {

        var color = hitEnemy.GetComponent<Image>().color;
        color.a = 0.8f;

        hitEnemy.GetComponent<Image>().color = color;

    }

    public void healtth()
    {

        var color = regen.GetComponent<Image>().color;
        color.a = 0.8f;

        regen.GetComponent<Image>().color = color;

    }



}
