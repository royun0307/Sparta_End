using UnityEngine;

public class StatusHealth : BaseStatus
{
    public float health;//���� ü��

    public override void Initialize(float initialValue)
    {
        base.Initialize(initialValue);
        health = initialValue;//���� ü�µ� �ʱ�ȭ
    }

    public override void SetStat(float value)
    {
        base.SetStat(value);
        if (value == 0)//�ּҰ��� 1
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

    public override string GetValueToString()//ü���� ����ü��/�ִ�ü�� ���� ��ȯ
    {
        return health.ToString() + "/" + base.GetValueToString();
    }
}
