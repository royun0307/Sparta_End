using System.Collections.Generic;
using UnityEngine;

public class CharacterStatus : MonoBehaviour
{
    [Header("Inintialize value")]
    [SerializeField] private float startAttck;
    [SerializeField] private float startDefence;
    [SerializeField] private float startMaxHealth;
    [SerializeField] private float startCritical;

    public StatusAttack attack;
    public StatusDefence defence;
    public StatusHealth health;
    public StatusCriticalRate critical;

    public Dictionary<StatType, BaseStatus> StatusDictionary {  get; private set; }


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

    private T AddAndInit<T>(float initValue) where T : BaseStatus
    {
        T status = gameObject.AddComponent<T>();
        status.Initialize(initValue);
        return status;
    }
}
