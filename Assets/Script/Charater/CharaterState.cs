using System;
using System.Collections.Generic;
using UnityEngine;

public class CharaterProperty : MonoBehaviour, ICharaterComponent
{
    [SerializeField] Transform charaterTransform;
    public Transform CharaterTransform => charaterTransform;

    [Header("Property")]
    [SerializeField] int health;
    public int Health => health;
    [SerializeField] float maxRegenerationReadyTime;
    [SerializeField] float regenerationReadyTimer;



    BuffList allBuffList = new BuffList();

    [SerializeField] float speed = 0.01f;
    public float BaseSpeed => speed;
    BuffList speedBuffList = new BuffList(PropertyEnum.speed);
    public float CurrentSpeed => speedBuffList.GetSpeed(speed);

    [SerializeField] float damageReductionRate = 1;
    public float DamageReductionRate => damageReductionRate;
    BuffList damageReductionRateList = new BuffList(PropertyEnum.damageReductionRate);
    public float CurrentDamageReductionRate => damageReductionRateList.GetDamageReductionRate(damageReductionRate);
    /// <summary>
    /// TODO
    /// 剩餘的玩家角色數值需要再寫
    /// 需要填寫的地方:PropertyEnum、上方四個變數、BuffListUpdate需要增加DeleteTimeoutBuff()、AddBuffState
    /// 、BuffList類別中需要增加遍歷Buff的函數(預設為相乘 若需要改為相加要再修改數值遍歷時處理方法)
    /// 代增加:增傷倍率、治療倍率
    /// </summary>

    

    public void ReceiveDamage(int damage)
    {
        damage = (int)Math.Round(CurrentDamageReductionRate*damage);
        DirectlyReceiveDamage(damage);
    }
    void DirectlyReceiveDamage(int damage)
    {
        health -= damage;
    }

    public void StateUpdate()
    {
        BuffListUpdate();
    }
    void BuffListUpdate()
    {
        allBuffList.StateUpdate();
        allBuffList.DeleteTimeoutBuff();
        speedBuffList.DeleteTimeoutBuff();
        damageReductionRateList.DeleteTimeoutBuff();
    }
    void AddBuffState(BuffState buffState)
    {
        buffState.ExecuteOnBuffAdded();
        HashSet<PropertyEnum> propertyEnums = buffState.PropertyEnums;
        foreach(PropertyEnum property in propertyEnums)
        {
            switch (property)
            {
                case PropertyEnum.speed:
                    speedBuffList.AddBuffState(buffState);
                    break;
                case PropertyEnum.damageReductionRate:
                    damageReductionRateList.AddBuffState(buffState);
                    break;
                default:
                    Debug.LogError($"Unfound property buff list:{property}");
                    break;
            }
        }
    }
    void Update()
    {

    }
}
