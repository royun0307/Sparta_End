using System;
using UnityEngine;

public class BaseStatus : MonoBehaviour
{
    public float value;

    public event Action<float> OnValueChanged;

    public virtual void SetStat(float amount)
    {
        if (amount < 0) return;//�ּڰ��� 0
        if (Mathf.Approximately(value, amount)) return;//value �� amount�� ���̰� ���� ���� ����X

        value = amount;
        OnValueChanged?.Invoke(value);
    }

    public void AddStatus(float amount)
    {
        SetStat(value + amount);
    }

    public void SubtractStatus(float amount)
    {
        SetStat(Mathf.Max(0, value - amount));
    }

    public virtual string GetValueToString()
    {
        return value.ToString();
    }
}
