using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[Serializable]
public class SavedData
{
    public int health; // health variable
    public float[] position; // puts position in float array
    public Inventory container; // inventory container
    public List<EnemyTurnbase> enemies = new List<EnemyTurnbase>(); // list of enemies

    
    public SavedData(Character character , Inventory inventoryObject )
    {
        position = new float[3]; // created three possition in array
        container = inventoryObject; // gets inventory
        health = character.health; // gets character health
       

        position[0] = character.transform.position.x;//gets position x
        position[1] = character.transform.position.y;// gets postion y
        position[2] = character.transform.position.z; //gets postion z

        //for(int i = 0; i< enemie.Count; i++)
        //        //{
        //        //    if(enemie[i].isDead == true)
        //        //    {
        //        //        enemie[i] =  null;



        //        //    }
        //        //    else if( enemie[i].isDead == false)
        //        //    {

        //        //        GameObject.Instantiate(enemie[i]);


        //        //    }


        //        //}



    }




}

