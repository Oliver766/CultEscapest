using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyTurnbase : MonoBehaviour
{

    public TurnBase turnSystem;
    public TurnBase.TurnClass turnClass;
    bool isMoving = false;

    public bool isDead;
    

 

    public float moveSpeed;

    public Transform[] patrolpoints;
    Transform currentPatrolPoint;
    int currenPatrolIndex;
    public Transform target;



    // Start is called before the first frame update
    void Start()
    {
        turnSystem = GameObject.Find("Turn-basedSystem").GetComponent<TurnBase>();

        foreach (TurnBase.TurnClass tc in turnSystem.PlayersGroup)
        {
            if (tc.playerGameObject.name == gameObject.name) turnClass = tc;
        }

        currenPatrolIndex = 1;
        currentPatrolPoint = patrolpoints[currenPatrolIndex];
    }

    // Update is called once per frame
    void Update()
    {
       
        
            if (turnClass.isTurn && isMoving == false)
            {
                
                Onturn();



            }


        

           



      

       
        


    }


    



    public void Onturn()
    {

        if (Vector3.Distance(transform.position, currentPatrolPoint.position) < 0.1f)
        {

            if (currenPatrolIndex + 1 < patrolpoints.Length)
            {
                currenPatrolIndex++;

            }
            else
            {
                currenPatrolIndex = 0;
                
            }


           


            turnSystem.EndTurn();
            isMoving = false;                
    
            currentPatrolPoint = patrolpoints[currenPatrolIndex];

        }

        StartCoroutine("Move");


    }


    IEnumerator Move() {

        //yield return new WaitForSeconds(1f);

        transform.position = Vector3.MoveTowards(transform.position, currentPatrolPoint.position, Time.deltaTime * moveSpeed);

        yield return null;

    }










}
