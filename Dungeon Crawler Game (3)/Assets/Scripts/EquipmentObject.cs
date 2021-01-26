using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Equipment Object", menuName = "Inventory System/Items/Equipment")] // creates menu
public class EquipmentObject : ItemObject
{
    public void Awake()
    {
        type = ItemType.Equipment; // creates item type for new item
    }
}
