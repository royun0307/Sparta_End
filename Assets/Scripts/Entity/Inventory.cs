using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    public int inventorySize;//인벤토리 크기
    public List<EquipmentData> inventory;//인벤토리

    public void AddItem(EquipmentData item)//아이템 추가
    {
        //예외처리
        if (inventory == null)
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

    public void RemoveItem(EquipmentData item)//아이템 제거
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
