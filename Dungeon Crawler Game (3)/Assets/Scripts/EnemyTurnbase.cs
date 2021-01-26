using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyTurnbase : MonoBehaviour
{

    public TurnBase turnSystem; // turn class reference
    public TurnBase.TurnClass turnClass; // turnclass game object reference
    bool isMoving = false; // is moving is false

    

    public GameObject text; // game object reference
 

    public float moveSpeed; // move speed

    public Transform[] patrolpoints; // patrol points
    Transform currentPatrolPoint; // current patrol points
    int currentPatrolIndex; // curent patrol index
    public Transform target; // target



    // Start is called before the first frame update
    void Start()
    {
        turnSystem = GameObject.Find("Turn-basedSystem").GetComponent<TurnBase>(); // gets turn base component

        foreach (TurnBase.TurnClass tc in turnSystem.PlayersGroup) // foreach turn class in turn system in player group
        {
            if (tc.playerGameObject.name == gameObject.name) turnClass = tc; // if playergame object equals gsme object .name
        }
        currentPatrolIndex = 1; // curent patrol index equals 1
        currentPatrolPoint = patrolpoints[currentPatrolIndex]; // current patrol points equals patrol points and current patrol index
    }

    // Update is called once per frame
    void Update()
    {
       
        
            if (turnClass.isTurn && isMoving == false) // if turn class .is turn and is moving is false
            {
                
                Onturn(); // run onturn function
                 StartCoroutine(Text()); // start coroutine


            }




    }


    public void Onturn()
    {

        if (Vector3.Distance(transform.position, currentPatrolPoint.position) < 0.1f) // if disance is less than 0.01f
        {

            if (currentPatrolIndex + 1 < patrolpoints.Length) // current patrolindex = 1 is greater than patrol point .length
            {
                currentPatrolIndex++; // add patrol point points to index

            }
            else
            {
                currentPatrolIndex = 0; // index is 0
                
            }


           


            turnSystem.EndTurn(); // end turn
            isMoving = false;  // is moving is false      
    
            currentPatrolPoint = patrolpoints[currentPatrolIndex]; // current patrol points is patrol pints and curren index

        }

        StartCoroutine("Move"); // start coroutine


    }


    IEnumerator Move() {

       

        transform.position = Vector3.MoveTowards(transform.position, currentPatrolPoint.position, Time.deltaTime * moveSpeed); // transform .position equals move towards patrol points
      
        yield return null; // retun null

    }



    public IEnumerator Text()
    {
        yield return new WaitForSeconds(0.5f); // wait for 0.05 seconds
        text.SetActive(true); // set object true
        yield return new WaitForSeconds(1); // wait one second
        text.SetActive(false); //object is set not active
       

    }







}
