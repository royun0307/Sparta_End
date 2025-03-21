using UnityEngine;

public class StatusHealth : BaseStatus
{
    public float maxHealth;

    public override void Initialize(float initialValue)
    {
        maxHealth = initialValue;
        base.Initialize(initialValue);
    }

    public override void SetStat(float value)
    {
        base.SetStat(value);
        if (value == 0)
        {
            value = 1f;
        }
        else if (value > maxHealth)
        {
            value = maxHealth;
        }
    }

    public void SetMaxHealth(float amount)
    {   
        maxHealth = amount;
        SetStat(value);
        if(amount <= 0)
        {
            maxHealth = 1;
        }
    }

    public void AddMaxHealth(float amount)
    {
        SetMaxHealth(maxHealth + amount);
    }

    public void SubstaractMaxHealth(float amount)
    {
        SetMaxHealth(Mathf.Max(0, maxHealth - amount));
    }

    public override string GetValueToString()
    {
        return base.GetValueToString() + "/" + maxHealth.ToString();
    }
}
