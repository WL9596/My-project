using System;
using UnityEngine;

[Serializable]
public abstract class BuffState
{
    int timer;//if timer == -1 , which mean this buff wont disappear
    public virtual float GetSpeed(float speed) { return speed; }
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
}
