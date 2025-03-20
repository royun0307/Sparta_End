using Unity.Mathematics;

public class StatusHealth : Status
{
    public float maxHealth = 100;

    public void Start()
    {
        value = maxHealth;
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
        if(amount <= 0)
        {
            maxHealth = 1;
        }
    }

    public override void AddStatus(float amount)
    {
        base.AddStatus(amount);
        if(amount > maxHealth)
        {
            value = maxHealth;
        }
    }

    public void AddMaxHealth(float amount)
    {
        maxHealth += amount;
    }

    public override void SubstractStatus(float amount)
    {
        base.SubstractStatus(amount);
        if (value == 0)
        {
            value = 1f;
        }
    }

    public void SubstaractMaxHealth(float amount)
    {
        maxHealth = math.max(0, maxHealth - amount);
    }
}
