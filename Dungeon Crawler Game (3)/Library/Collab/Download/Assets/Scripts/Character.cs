using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class Character : MonoBehaviour
{
    [SerializeField]
    [Range(2, 12)] // speed of character
    private float speed = 4; // float
    
    public InventoryObject container;
    public Inventory inventory; // reference to inventory class
    public int health; // health of player
    public BattleHud phud; // reference to player health bar;
    
 



    public Vector3 targetPosition; // target position when player moves
    private bool isMoving = false; // to check is player moves


    public TurnBase turnSystem; // reference to turn base system
    public TurnBase.TurnClass turnClass; // reference to turn class
    public Unit playerunit; // reference to player unit from battle scene
  

    




    public void Start() {

        health = playerunit.currentHP; // health equals player unit and current health

        turnSystem = GameObject.Find("Turn-basedSystem").GetComponent<TurnBase>(); // find turn based system and gets turn based component

        foreach (TurnBase.TurnClass tc in turnSystem.PlayersGroup) // foreach loop, for turn class in players group
        {
            if (tc.playerGameObject.name == gameObject.name) turnClass = tc; // checks if game object is a playergame object
            if (tc.playerGameObject.name == gameObject.name) turnClass = tc;// checks if game object is a playergame object
        }





    }

    






    public void OnTriggerEnter2D(Collider2D other) // on trigger enter fucntion
    {
        var item = other.GetComponent<GroundItem>(); // gets grounditem component
        if (item)
        {
            Item _item = new Item(item.item); // sets item
            Debug.Log(_item.Id);
            container.AddItem(_item, 1); // adds item to inventory
            Destroy(other.gameObject); // destroy item
        }
    }

    private void OnApplicationQuit() // quit method
    {
        inventory.Items = new InventorySlot[4]; // refreshed inventory on quit
    }

    // Update is called once per frame
    void Update()
    {
        


        if (turnClass.isTurn) // if it is players turn
        {


            if (Input.GetMouseButton(0) && !EventSystem.current.IsPointerOverGameObject()) // if mouse button is pressed and event is triggered
            {

                SetTargetPostion(); // set target position




            }

            if (isMoving) // if is moving
            {
                Move(); // move function

            }




        }






    }



    public void SetTargetPostion() // set target position
    {

        targetPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition); // set target position to main camera screentoworld point
        targetPosition.z = transform.position.z; // targetposition.z equals targetposition.z
        isMoving = true; // ismoving equals true;



    }

    public void Move() // move function
    {
     
        
      

       transform.position = Vector3.MoveTowards(transform.position, targetPosition, speed * Time.deltaTime); // transport position equals vector 3 move towards


        if (transform.position == targetPosition) // if tranport.posiion equals targetposition
        {


            isMoving = false; //is moving equals false
            turnSystem.EndTurn(); // end turn


        }

    }

    
    public void OnCollisionEnter2D(Collision2D collision2D) // collision function
    {
        if(collision2D.gameObject.CompareTag("Collider")) // if tag of object is collider
        {
            isMoving = false; //is moving equals false
            turnSystem.EndTurn();// end turn


        }


    }



}

  




   


  

