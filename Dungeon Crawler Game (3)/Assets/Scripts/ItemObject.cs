using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ItemType // list of item types
{
    
    Equipment,
    Default
}


public abstract class ItemObject : ScriptableObject
{
    public int Id; // gets id
    public Sprite uiDisplay; // gets sprite display
    public ItemType type; // item type
    [TextArea(15, 20)] // text area
    public string description; // description
    

    public Item CreateItem() // creates new item
    {
        Item newItem = new Item(this); // created item with name and id
        return newItem; // returns new item
    }
}

[System.Serializable]
public class Item
{
    public string Name; // sets item name
    public int Id; // sets item id
   
    public Item(ItemObject item) 
    {
        Name = item.name; // gets item name
        Id = item.Id; // gets item id
       
    }
}

