using System;
using UnityEngine;

public class BaseStatus : MonoBehaviour
{
    public float value;//��

    public event Action<float> OnValueChanged;//������ ���ҽ� ����

    public virtual void Initialize(float initialValue)//�ʱ�ȭ
    {
        SetStat(initialValue);
    }   

    public virtual void SetStat(float amount)//���� ����
    {
        if (amount < 0) return;//0���� ������ ���� X
        if (Mathf.Approximately(value, amount)) return;//value �� amount�� ���̰� ���� ���� ����X

        value = amount;
        OnValueChanged?.Invoke(value);//�׼� ����
    }

    public void AddStatus(float amount)
    {
        SetStat(value + amount);
    }

    public void SubtractStatus(float amount)
    {
        SetStat(Mathf.Max(0, value - amount));//�ּڰ��� 0
    }

    public virtual string GetValueToString()//string���� ��ȯ
    {
        return value.ToString();
    }
}
