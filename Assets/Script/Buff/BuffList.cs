using UnityEngine;
using System.Collections.Generic;
using System;
using System.Text;
using Unity.VisualScripting;

[Serializable]
public class BuffList
{
    [SerializeField] PropertyEnum property = PropertyEnum.none;
    public BuffList() { }
    public BuffList(PropertyEnum propertyEnum)
    {
        property = propertyEnum;
    }
    [SerializeField] List<BuffState> buffList = new List<BuffState>();

    public string PrintAllBuff()
    {
        StringBuilder stringBuilder = new StringBuilder("all buff:\n");
        foreach (BuffState buffState in buffList)
        {
            stringBuilder.Append($"{buffState.GetType()} time:{buffState.Timer}");
        }
        return stringBuilder.ToString();
    }
    public void RemoveAllBuff()
    {
        int amount = buffList.Count;
        for (int i = amount - 1; i >= 0; i--)
        {
            buffList.RemoveAt(i);
        }
    }
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
    public bool GetIsEnableRotate(bool isEnableRotate)
    {
        foreach (BuffState buffState in buffList)
        {
            isEnableRotate = buffState.GetIsEnableRotate(isEnableRotate) ? isEnableRotate : false;
        }
        return isEnableRotate;
    }
}
