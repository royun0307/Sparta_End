public class StatusCriticalRate : BaseStatus
{
    public override void SetStat(float value)
    {
        base.SetStat(value);
        if (value > 100f)//�ִ밪�� 100
        {
            value = 100f;
        }
    }
}
