using UnityEngine;
using System.Collections.Generic;

public class BuffList
{
    PropertyEnum property = PropertyEnum.none;
    public BuffList(){}
    public BuffList(PropertyEnum propertyEnum)
    {
        property = propertyEnum;
    }
    List<BuffState> buffList = new List<BuffState>();

    public void AddBuffState(BuffState buffState)
    {
        buffList.Add(buffState);
    }
    public void StateUpdate()
    {
        int amount = buffList.Count;
        for (int i = amount - 1; i >= 0; i--)
        {
            buffList[i].StateUpdate();
        }
    }
    public void DeleteTimeoutBuff()
    {
        int amount = buffList.Count;
        for (int i = amount - 1; i >= 0; i--)
        {
            if (buffList[i].IsDeleteBuff())
            {
                buffList.RemoveAt(i);
            }
        }
    }
    public float GetSpeed(float speed)
    {
        foreach (BuffState buffState in buffList)
        {
            speed = buffState.GetSpeed(speed);
        }
        return speed;
    }
    public float GetDamageReductionRate(float damageReductionRate)
    {
        foreach (BuffState buffState in buffList)
        {
            damageReductionRate = buffState.GetDamageReductionRate(damageReductionRate);
        }
        return damageReductionRate;
    }
}
