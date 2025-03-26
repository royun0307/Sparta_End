using System;
using UnityEngine;

public class BaseStatus : MonoBehaviour
{
    public float value;//값

    public event Action<float> OnValueChanged;//스탯이 변할시 실행

    public virtual void Initialize(float initialValue)//초기화
    {
        SetStat(initialValue);
    }   

    public virtual void SetStat(float amount)//스탯 변경
    {
        if (amount < 0) return;//0보다 작으면 변경 X
        if (Mathf.Approximately(value, amount)) return;//value 와 amount의 차이가 작을 때는 실행X

        value = amount;
        OnValueChanged?.Invoke(value);//액션 실행
    }

    public void AddStatus(float amount)
    {
        SetStat(value + amount);
    }

    public void SubtractStatus(float amount)
    {
        SetStat(Mathf.Max(0, value - amount));//최솟값은 0
    }

    public virtual string GetValueToString()//string으로 변환
    {
        return value.ToString();
    }
}
