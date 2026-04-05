using UnityEngine;

public class DamageBuffInfo
{
    public virtual void OnBuffExecute() { }
    public virtual BuffState BuildBuffState() { return null; }
}
