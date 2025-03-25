using UnityEngine;
using System.Collections.Generic;

public class EquipmentManager : MonoBehaviour
{
    private Dictionary<EquipmentType, EquipmentData> equippedEquipment = new Dictionary<EquipmentType, EquipmentData>();

    public void Equip(EquipmentData equipment)
    {
        if (equipment == null) return;

        EquipmentType type = equipment.equipmentType;
        

        if (equippedEquipment.ContainsKey(type))
        {
            Unequip(equippedEquipment[type]);
        }
        equippedEquipment[type] = equipment;
        Debug.Log($"{equipment.equipmentType.ToString()} {equipment.itemName}을 장착했습니다.");
        ApplyEquipmentStats(equipment, true);
    }

    public void Unequip(EquipmentData equipment)
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

    private void ApplyEquipmentStats(EquipmentData equipment, bool isEquipping)
    {
        float multiplier = isEquipping ? 1f : -1f;
        Dictionary<StatType, float> modifiers = equipment.GetBaseStatusModifiers();

        foreach (var kvp in modifiers)
        {
            if (GameManager.Instance.Player.status.StatusDictionary.TryGetValue(kvp.Key, out BaseStatus status))
            {
                status.AddStatus(kvp.Value * multiplier);
            }
        }
    }

    public bool IsEquipped(EquipmentData equipment)
    {
        return equippedEquipment.TryGetValue(equipment.equipmentType, out EquipmentData current) && current == equipment;
    }
}
