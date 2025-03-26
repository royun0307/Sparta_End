using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{
    public EquipmentManager equipmentManager;
    public CharacterStatus status;
    public Inventory inventory;
    public CharacterInfo characterInfo;

    private void Awake()
    {
        equipmentManager = GetComponent<EquipmentManager>();
        status = GetComponent<CharacterStatus>();
        inventory = GetComponent<Inventory>();
        characterInfo = GetComponent<CharacterInfo>();
    }
}
