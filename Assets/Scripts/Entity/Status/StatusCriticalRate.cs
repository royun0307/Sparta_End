public class StatusCriticalRate : BaseStatus
{
    public override void SetStat(float value)
    {
        base.SetStat(value);
        if (value > 100f)//최대값은 100
        {
            value = 100f;
        }
    }
}
