using UnityEngine;
using System.Collections.Generic;

public class BuffList
{
    List<BuffState> buffList = new List<BuffState>();


    public void StateUpdate()
    {
        int amount = buffList.Count;
        for (int i = amount - 1; i >= 0; i--)
        {
            buffList[i].StateUpdate();
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
}
