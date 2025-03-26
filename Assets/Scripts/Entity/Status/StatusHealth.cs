using UnityEngine;

public class StatusHealth : BaseStatus
{
    public float health;//현재 체력

    public override void Initialize(float initialValue)
    {
        base.Initialize(initialValue);
        health = initialValue;//현재 체력도 초기화
    }

    public override void SetStat(float value)
    {
        base.SetStat(value);
        if (value == 0)//최소값은 1
        {
            value = 1f;
        }
        else if (value < health)
        {
            health = value;
        }
    }

    public void SetHealth(float amount)
    {   
        health = amount;
        SetStat(value);
    }

    public void AddHealth(float amount)
    {
        SetHealth(health + amount);
    }

    public void SubstaractHealth(float amount)
    {
        SetHealth(Mathf.Max(0, health - amount));
    }

    public override string GetValueToString()//체력은 현재체력/최대체력 으로 변환
    {
        return health.ToString() + "/" + base.GetValueToString();
    }
}
