using System;
using System.Collections.Generic;
using UnityEngine;

public class RrroseHealthCircle : OWObject
{
    [SerializeField] float healthCooldown;
    [SerializeField] int healValue;
    List<(Charater,float)> charaterList = new List<(Charater,float)>();
    public int teamTag;
    public override void StateUpdate()
    {
        
        for(int i=0;i<charaterList.Count;i++)
        {
            float newTimer = charaterList[i].Item2-Time.deltaTime;
            if(newTimer<=0)
            {
                EffectOnCharater(charaterList[i].Item1);
                newTimer = healthCooldown;
            }
            charaterList[i] = (charaterList[i].Item1,newTimer);
        }
    }
    void EffectOnCharater(Charater charater)
    {
        DamageInfo damageInfo;
        if(charater.TeamTag == teamTag)
        {
            damageInfo = new DamageInfo();
            damageInfo.damage = -healValue;
        }
        else
        {
            damageInfo = new DamageInfo();
            damageInfo.damage = healValue;
        }
        charater.ReceiveDamageInfo(damageInfo);
        
    }
    void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.TryGetComponent<Charater>(out var value))
        {
            charaterList.Add((value,healthCooldown));
        }
    }
    void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.TryGetComponent<Charater>(out var value))
        {
            int amount = charaterList.Count;
            for(int i = amount-1;i>=0;i--)
            {
                if(charaterList[i].Item1==value)
                {
                    charaterList.RemoveAt(i);
                }
            }
        }
    }
}
