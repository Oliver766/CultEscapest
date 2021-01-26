using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Unit : MonoBehaviour
{
   
   

    public int damage; // damage set
    public string unitName; // name of unit
    public int UnitLevel; // unit level

    public int maxHP; // max health
    public int currentHP; // gets curren health

    public int minHP; // min health

        
    public bool TakeDamage(int dmg)
    {
        currentHP -= dmg; // damage is taken away from curren health
        if (currentHP <= 0) // if curren health is less than or equal to 0
        {
            return true; // retun true


        }
        else
        {
            return false; // return false
        }



    }

    public void Heal(int amount)
    {

        currentHP += amount; // amount is added on to curren health
        if(currentHP> maxHP) // if curren health is bigger than max health
        {

            currentHP = maxHP; // cure health is equall to max hp

        }




    }
    


   
}
