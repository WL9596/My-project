using System;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public abstract class BuffState
{
    protected HashSet<PropertyEnum> propertyEnums;
    public HashSet<PropertyEnum> PropertyEnums => propertyEnums;
    protected int timer;//if timer == -1 , which mean this buff wont disappear
    
    public virtual void StateUpdate()
    {
        if (timer != -1 && timer > 0)
        {
            timer--;
        }
    }
    public virtual bool IsDeleteBuff()
    {
        return timer == 0;
    }
    public void RemoveState()
    {
        timer =0;
    }
    public virtual void ExecuteOnBuffAdded(){}

    public virtual float GetSpeed(float speed) { return speed; }
    public virtual float GetDamageReductionRate(float damageReductionRate) { return damageReductionRate; }
    public virtual bool GetIsEnableRotate(bool isEnableRotate){return isEnableRotate;}
}
