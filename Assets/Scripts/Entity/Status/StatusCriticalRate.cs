public class StatusCriticalRate : Status
{
    public override void SetStat(float value)
    {
        base.SetStat(value);
        if (value < 0f)
        {
            value = 0f;
        }
        else if (value > 100f)
        {
            value = 100f;
        }
    }

    public override void AddStatus(float amount)
    {
        base.AddStatus(amount);
        if(value > 100f)
        {
            value = 100f;
        }
    }
}
