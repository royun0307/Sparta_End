using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{
    public EquipmentManager equipmentManager;//장비 장착
    public CharacterStatus status;//스탯
    public Inventory inventory;//인벤토리
    public CharacterInfo characterInfo;//캐릭터 정보

    private void Awake()
    {
        equipmentManager = GetComponent<EquipmentManager>();
        status = GetComponent<CharacterStatus>();
        inventory = GetComponent<Inventory>();
        characterInfo = GetComponent<CharacterInfo>();
    }
}
