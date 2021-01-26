using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class TurnBase : MonoBehaviour
{
    public List<TurnClass> PlayersGroup; // list of  game objects
   
    //public Character character;

    [System.Serializable]
    public class TurnClass
    {


        public GameObject playerGameObject;//  add each object to turnclass
        public bool isTurn = false; // sets is turn to false

    }



    void Start()
    {
        ResetTurns(); // runs reset turn function



    }

    public void Update()
    {
        //UpdateTurns();


    }

    public void ResetTurns()
    {
        for (int i = 0; i < PlayersGroup.Count; i++) // counts through list
        {

            if (i == 0) // if index equals 0
            {
                PlayersGroup[i].isTurn = true; // 1st item  is true




            }
            else
            {

                PlayersGroup[i].isTurn = false; // else 1st object has not got there turn



            }

        }
    }



        public void UpdateTurns()
        {
            for (int i = 0; i < PlayersGroup.Count; i++)  // counts through list
            {
                if (!PlayersGroup[i].isTurn) //  if it isn't players turn
                {

                    PlayersGroup[i].isTurn = true;  // the enemies have there turn

                }
                else if (i == PlayersGroup.Count - 1) // if it runs through all of list
                {
                    ResetTurns(); // do rest turn function



                }
                else
                {
                    PlayersGroup[i].isTurn = false; // its's not enemies turn
                }

            }


        }

        public void EndTurn() // end turn function
        {
            Debug.Log("Turn has Ended");
            UpdateTurns(); // when each player/ enemies turn has ended



        }

    
}
        


