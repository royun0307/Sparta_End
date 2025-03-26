using System.Collections.Generic;
using UnityEngine;

public class CharacterStatus : MonoBehaviour
{
    [Header("Inintialize value")]
    [SerializeField] private float startAttck;//���ݷ� �ʱⰪ
    [SerializeField] private float startDefence;//���� �ʱⰪ
    [SerializeField] private float startMaxHealth;//ü�� �ʱⰪ
    [SerializeField] private float startCritical;//ġ��Ÿ �ʱⰪ

    public StatusAttack attack;//���ݷ�
    public StatusDefence defence;//����
    public StatusHealth health;//ü��
    public StatusCriticalRate critical;//ġ��Ÿ

    public Dictionary<StatType, BaseStatus> StatusDictionary {  get; private set; }//StatType�� BaseStatus����


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

    private T AddAndInit<T>(float initValue) where T : BaseStatus//���۳�Ʈ�� �߰� �ϰ� �ʱ�ȭ
    {
        T status = gameObject.AddComponent<T>();
        status.Initialize(initValue);
        return status;
    }
}
