using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class TurnBase : MonoBehaviour
{
    public List<TurnClass> PlayersGroup;
   
    //public Character character;

    [System.Serializable]
    public class TurnClass
    {


        public GameObject playerGameObject;
        public bool isTurn = false;

    }



    void Start()
    {
        ResetTurns();



    }

    public void Update()
    {
        //UpdateTurns();


    }

    public void ResetTurns()
    {
        for (int i = 0; i < PlayersGroup.Count; i++)
        {

            if (i == 0)
            {
                PlayersGroup[i].isTurn = true;




            }
            else
            {

                PlayersGroup[i].isTurn = false;



            }

        }
    }



        public void UpdateTurns()
        {
            for (int i = 0; i < PlayersGroup.Count; i++)
            {
                if (!PlayersGroup[i].isTurn)
                {

                    PlayersGroup[i].isTurn = true;

                }
                else if (i == PlayersGroup.Count - 1)
                {
                    ResetTurns();



                }
                else
                {
                    PlayersGroup[i].isTurn = false;
                }

            }


        }

        public void EndTurn()
        {
            Debug.Log("Turn has Ended");
            UpdateTurns();



        }

    
}
        


