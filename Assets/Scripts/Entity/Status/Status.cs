using Unity.Mathematics;
using UnityEngine;

public class Status : MonoBehaviour
{
    public float value;

    public virtual void SetStat(float value)
    {
        if (value <= 0) return;
        this.value = value;
    }

    public virtual void AddStatus(float amount)
    {
        value += amount;
    }

    public virtual void SubstractStatus(float amount)
    {
        value = math.max(value, value - amount);
    }
}
