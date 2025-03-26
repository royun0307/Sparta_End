using UnityEngine;
using System.Collections.Generic;

public class EquipmentManager : MonoBehaviour
{
    //EquipmentType에 따라 각각 장착 가능
    private Dictionary<EquipmentType, EquipmentData> equippedEquipment = new Dictionary<EquipmentType, EquipmentData>();

    public void Equip(EquipmentData equipment)//장착
    {
        if (equipment == null) return;

        EquipmentType type = equipment.equipmentType;
        

        if (equippedEquipment.ContainsKey(type))//같은 타입이 장비 되어 있으면
        {
            Unequip(equippedEquipment[type]);
        }
        equippedEquipment[type] = equipment;
        Debug.Log($"{equipment.equipmentType.ToString()} {equipment.itemName}을 장착했습니다.");
        ApplyEquipmentStats(equipment, true);//스탯 변환
    }

    public void Unequip(EquipmentData equipment)//해제
    {
        if (equipment == null) return;

        EquipmentType type = equipment.equipmentType;
        if (equippedEquipment.ContainsKey(type) && equippedEquipment[type] == equipment)
        {
            equippedEquipment.Remove(type);
            Debug.Log($"{equipment.equipmentType.ToString()} {equipment.itemName}을 장착 해제했습니다.");
            ApplyEquipmentStats(equipment, false);
        }
    }

    private void ApplyEquipmentStats(EquipmentData equipment, bool isEquipping)//스탯 변환
    {
        float multiplier = isEquipping ? 1f : -1f;//장착이면 1, 해제면 -1
        Dictionary<StatType, float> modifiers = equipment.GetBaseStatusModifiers();

        foreach (var kvp in modifiers)
        {
            if (GameManager.Instance.Player.status.StatusDictionary.TryGetValue(kvp.Key, out BaseStatus status))
            {
                status.AddStatus(kvp.Value * multiplier);//스탯에 적용
            }
        }
    }

    public bool IsEquipped(EquipmentData equipment)
    {
        return equippedEquipment.TryGetValue(equipment.equipmentType, out EquipmentData current) && current == equipment;
    }
}
