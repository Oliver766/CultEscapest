using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BattleHud : MonoBehaviour
{

    public Slider hpSlider; // sets hp slider

    

   public void SetHud( Unit unit)
   {

        hpSlider.maxValue = unit.maxHP; // hpslider .max slider is equall to unit .max hp
        hpSlider.value = unit.currentHP; // hpslider.value = unit.curren hp ix equal to unit.current hp

   }

    public void SetHP(int HP)
    {

        hpSlider.value = HP; // hp value is equal to hp

    }

    

}
