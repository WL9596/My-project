public class FrozenBuffInfo : DamageBuffInfo
{
    float frozenTime;
    public FrozenBuffInfo(float frozenTime)
    {
        this.frozenTime = frozenTime;
    }
    public override BuffState BuildBuffState()
    {
        return new FrozenBuff(frozenTime);
    }
}