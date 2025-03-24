public enum StatType
{
    Attack,
    Defence,
    Health,
    Critical
}

[System.Serializable]
public class StatModifier 
{
    public StatType statType;
    public float value;
}
