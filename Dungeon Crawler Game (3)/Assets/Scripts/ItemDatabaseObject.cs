using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Item Database", menuName = "resources/Inventory System/Items/Database")]
public class ItemDatabaseObject : ScriptableObject, ISerializationCallbackReceiver
{
    public ItemObject[] Items; // items in database
    public Dictionary<int, ItemObject> GetItem = new Dictionary<int, ItemObject>(); // create list of item objects and numbers

    public void OnAfterDeserialize()
    {
        for (int i = 0; i < Items.Length; i++) // counts the items in databse
        {
            Items[i].Id = i; // gets id
            GetItem.Add(i, Items[i]); // add items to databse
        }
    }

    public void OnBeforeSerialize()
    {
        GetItem = new Dictionary<int, ItemObject>(); // puts items in dictionary
    }
}
