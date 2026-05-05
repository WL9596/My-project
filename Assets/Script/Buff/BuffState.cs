using System;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public abstract class BuffState
{
    protected HashSet<PropertyEnum> propertyEnums;
    public HashSet<PropertyEnum> PropertyEnums => propertyEnums;
    [SerializeField] protected float timer;//if timer == -1 , which mean this buff wont disappea
    public float Timer => timer;
    
    public virtual void StateUpdate()
    {
        if (timer != -1 && timer > 0)
        {
            timer-=Time.deltaTime;
        }
    }
    public virtual bool IsDeleteBuff()
    {
        return timer <= 0 && timer!=-1;
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
