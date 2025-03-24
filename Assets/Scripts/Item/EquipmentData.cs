using System.Collections.Generic;
using UnityEngine;

public enum EquipmentType
{
    Weapon,
    Armor,
    Accessory
}

[CreateAssetMenu(fileName= "NewEquipment", menuName = "Item/Equipment")]
public class EquipmentData : ItemData
{
    public EquipmentType equipmentType;
    public List<StatModifier> statModifiers = new List<StatModifier>();

    public Dictionary<StatType, float> GetBaseStatusModifiers()
    {
        Dictionary<StatType, float> modifiers = new Dictionary<StatType, float>();
        foreach (var mod in statModifiers)
        {
            if (modifiers.ContainsKey(mod.statType))
                modifiers[mod.statType] += mod.value;
            else
                modifiers.Add(mod.statType, mod.value);
        }
        return modifiers;
    }
}
