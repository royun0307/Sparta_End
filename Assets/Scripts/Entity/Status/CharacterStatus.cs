using UnityEngine;

public class CharacterStatus : MonoBehaviour
{
    public StatusAttack attack;
    public float startAttck;

    public StatusDefence defence;
    public float startDefence;

    public StatusHealth health;
    public float startMaxHealth;

    public StatusCriticalRate critical;
    public float startCritical;

    private void Awake()
    {
        attack = gameObject.AddComponent<StatusAttack>();
        defence = gameObject.AddComponent<StatusDefence>();
        health = gameObject.AddComponent<StatusHealth>();
        critical = gameObject.AddComponent<StatusCriticalRate>();

        attack.value = startAttck;
        defence.value = startDefence;
        health.maxHealth = startMaxHealth;
        critical.value = startCritical;
    }
}
