public class StatusCriticalRate : BaseStatus
{
    public override void SetStat(float value)
    {
        base.SetStat(value);
        if (value > 100f)
        {
            value = 100f;
        }
    }
}
