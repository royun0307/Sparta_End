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


    private void Awake()
    {
        attack = AddAndInit<StatusAttack>(startAttck);
        defence = AddAndInit<StatusDefence>(startDefence);
        health = AddAndInit<StatusHealth>(startMaxHealth);
        critical = AddAndInit<StatusCriticalRate>(startCritical);
    }

    private T AddAndInit<T>(float initValue) where T : BaseStatus
    {
        T status = gameObject.AddComponent<T>();
        status.Initialize(initValue);
        return status;
    }
}
