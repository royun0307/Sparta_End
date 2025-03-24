using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    public int inventorySize;
    public List<EquipmentData> inventory;

    public void AddItem(EquipmentData item)
    {
        if(inventory == null)
        {
            Debug.LogError("Inventory is null");
            return;
        }

        if (inventory.Count <= inventorySize)
        {
            inventory.Add(item);
        }
        else
        {
            Debug.Log("Inventory is Full");
        }
    }

    public void RemoveItem(EquipmentData item) 
    { 
        for(int i = 0; i < inventory.Count; i++)
        {
            if (inventory[i] == item)
            {
                inventory.RemoveAt(i);
                return;
            }
        }
    }
}
