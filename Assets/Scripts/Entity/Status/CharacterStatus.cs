using System.Collections.Generic;
using UnityEngine;

public class CharacterStatus : MonoBehaviour
{
    [Header("Inintialize value")]
    [SerializeField] private float startAttck;//공격력 초기값
    [SerializeField] private float startDefence;//방어력 초기값
    [SerializeField] private float startMaxHealth;//체력 초기값
    [SerializeField] private float startCritical;//치명타 초기값

    public StatusAttack attack;//공격력
    public StatusDefence defence;//방어력
    public StatusHealth health;//체력
    public StatusCriticalRate critical;//치명타

    public Dictionary<StatType, BaseStatus> StatusDictionary {  get; private set; }//StatType과 BaseStatus연결


    private void Awake()
    {
        attack = AddAndInit<StatusAttack>(startAttck);
        defence = AddAndInit<StatusDefence>(startDefence);
        health = AddAndInit<StatusHealth>(startMaxHealth);
        critical = AddAndInit<StatusCriticalRate>(startCritical);

        StatusDictionary = new Dictionary<StatType, BaseStatus>
        {
            { StatType.Attack, attack },
            { StatType.Defence, defence },
            { StatType.Health, health },
            { StatType.Critical, critical }
        };
    }

    private T AddAndInit<T>(float initValue) where T : BaseStatus//컴퍼넌트를 추가 하고 초기화
    {
        T status = gameObject.AddComponent<T>();
        status.Initialize(initValue);
        return status;
    }
}
