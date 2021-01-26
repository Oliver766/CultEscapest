using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Text;
using System;

public class PlayerSave : MonoBehaviour
{
    #region Singleton



    public static PlayerSave Instance { get; private set; } // creates instance of player save

    private void Awake()
    {
        if (Instance != null && Instance != this) // if instance is not null and instance does not equal this
        {

            Destroy(this.gameObject); // destroy game object


        }
        else
        {

            Instance = this; // instance equals this
        }


    }



    #endregion 

    public InventoryObject Inventory; // gets inventor reference
    public Character Character; // gets chracter reference
    public string path; // file path
    public Unit playerUnit;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space)) // if key code is space
        {
            Save(); // save game
        }
        if (Input.GetKeyDown(KeyCode.L)) // if key code is L
        {
            Load(); // load game
         }

    }

    public void Save()
    {

        SavedData savedData = new SavedData(); // creates new save object
        savedData.characterHealth = Character.health; // sets character health
        savedData.characterHealth = playerUnit.currentHP;// sets character health
        savedData.characterPosition = Character.targetPosition; // sets character position


        for (int i = 0; i < Inventory.inventory.Items.Length;i++) // counts through inventory
        {
            savedData.Inventory[i] = Inventory.inventory.Items[i]; // save inventory data
         }

        string data = JsonUtility.ToJson(savedData); // sends it to text file

        Debug.Log(data);

        File.WriteAllText(Application.persistentDataPath + path, data); // writes call to file path and data

    }


    public void Load()
    {
        string data = File.ReadAllText(Application.persistentDataPath + path); // read all text frompath
                
        SavedData savedData = JsonUtility.FromJson<SavedData>(data); // loads data out

        Character.health = savedData.characterHealth; // gets character health
        playerUnit.currentHP = savedData.characterHealth;// gets character health
        Character.transform.position = savedData.characterPosition; // gets character position
 
        for (int i = 0; i < savedData.Inventory.Length;i++) // counts through inventory in saved daat
        {
            Inventory.inventory.Items[i].UpdateSlot( savedData.Inventory[i].ID, savedData.Inventory[i].item, savedData.Inventory[i].amount); // updats inventory slots
        }


    }


    private void OnApplicationQuit() // quit method
    {
        Inventory.inventory.Items = new InventorySlot[4]; // refreshed inventory on quit
    }


}


public class SavedData
    {
        public int characterHealth; // set character health
        public Vector3 characterPosition; // sets character position
        public InventorySlot[] Inventory = new InventorySlot[4]; // sets inventory slots 4 times

}
























