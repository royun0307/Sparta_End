using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{
    public EquipmentManager equipmentManager;
    public CharacterStatus status;
    public Inventory inventory;

    private void Awake()
    {
        equipmentManager = GetComponent<EquipmentManager>();
        status = GetComponent<CharacterStatus>();
        inventory = GetComponent<Inventory>();
    }
}
