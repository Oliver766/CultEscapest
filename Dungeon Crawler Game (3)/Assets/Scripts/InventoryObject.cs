using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using UnityEditor;
using System.Runtime.Serialization;

[CreateAssetMenu(fileName = "New Inventory", menuName = "resources/Inventory System/Inventory")]
public class InventoryObject : ScriptableObject
{



    public ItemDatabaseObject database; // receives databse
    public Inventory inventory; // inventory class



    public void AddItem(Item _item, int _amount)
    {
        //if (_item.buffs.Length > 0) // if item buffs .length is greater than 0
        //{
        //    SetEmptySlot(_item, _amount); // set empty slot
        //    return;
        //}

        for (int i = 0; i < inventory.Items.Length; i++) // checks the items in inventory
        {
            if (inventory.Items[i].ID == _item.Id) //  if items in inventory equal items . id
            {
                inventory.Items[i].AddAmount(_amount); // add items and amount
                return;
            }
        }


        SetEmptySlot(_item, _amount); // sets slot empty

    }
    public InventorySlot SetEmptySlot(Item _item, int _amount)
    {
        for (int i = 0; i < inventory.Items.Length; i++)// checks the items in inventory
        {
            if (inventory.Items[i].ID <= -1) // if inventory slot item id equals and or less than - 1
            {
                inventory.Items[i].UpdateSlot(_item.Id, _item, _amount); // update inventory slot
                return inventory.Items[i]; // returns items to inventory
            }
        }
        //set up functionality for full inventory
        return null;
    }

    public void MoveItem(InventorySlot item1, InventorySlot item2)
    {
        InventorySlot temp = new InventorySlot(item2.ID, item2.item, item2.amount); // created temporary  inventory slots
        item2.UpdateSlot(item1.ID, item1.item, item1.amount); // updates  inventory slots  item 1 and item 2
        item1.UpdateSlot(temp.ID, temp.item, temp.amount); // creates temporary  id, item and amount of slot
    }


    public void RemoveItem(Item _item)
    {
        for (int i = 0; i < inventory.Items.Length; i++)// checks the items in inventory
        {
            if (inventory.Items[i].item == _item) // if item  in inventory equals item
            {
                inventory.Items[i].UpdateSlot(-1, null, 0); // remove items and set id to -1, item to null and amount to 0
            }
        }
    }

  
}


[System.Serializable]
public class Inventory
{
    public InventorySlot[] Items = new InventorySlot[4]; // sets slots to 4
}



[System.Serializable]
public class InventorySlot
{
    public int ID = -1; // gets id to -1
    public Item item; // gets item
    public int amount; // gets amount
   
    public InventorySlot()
    {
        ID = -1; // sets id to -1
        item = null; // sets item to null
        amount = 0; // sets amount to 0
    }
    public InventorySlot(int _id, Item _item, int _amount)
    {
        ID = _id; // sets id to id
        item = _item; // sets item to item
        amount = _amount; // sets amount to amount
    }
    public void UpdateSlot(int _id, Item _item, int _amount )
    {
        ID = _id; // sets id to id
        item = _item;// sets item to item
        amount = _amount;// sets amount to amount
    }
    public void AddAmount(int value)
    {
        amount += value; // ads value of item with amount
    }
}
