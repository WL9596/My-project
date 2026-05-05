using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

public class CharaterProperty : MonoBehaviour, ICharaterComponent
{
    [SerializeField] Transform charaterTransform;
    public Transform CharaterTransform => charaterTransform;


    [Header("Property")]
    [SerializeField] int health;
    public int Health => health;
    [SerializeField] int maxHealth;
    [SerializeField] int blueHealth;
    public int BlueHealth => blueHealth;
    [SerializeField] float maxRegenerationReadyTime;
    [SerializeField] float regenerationReadyTimer;



    BuffList allBuffList = new BuffList();

    [SerializeField] float originalSpeed = 0.01f;
    public float BaseSpeed => originalSpeed;
    public float CurrentSpeed => allBuffList.GetSpeed(originalSpeed);

    [SerializeField] bool originalIsEnableRotation = true;
    public bool CurrentIsEnableRotation => allBuffList.GetIsEnableRotate(originalIsEnableRotation);

    [SerializeField] float damageReductionRate = 1;
    public float DamageReductionRate => damageReductionRate;
    public float CurrentDamageReductionRate => allBuffList.GetDamageReductionRate(damageReductionRate);
    /// <summary>
    /// TODO
    /// 剩餘的玩家角色數值需要再寫
    /// 需要填寫的地方:PropertyEnum、上方四個變數、BuffListUpdate需要增加DeleteTimeoutBuff()、AddBuffState
    /// 、BuffList類別中需要增加遍歷Buff的函數(預設為相乘 若需要改為相加要再修改數值遍歷時處理方法)
    /// 代增加:增傷倍率、治療倍率
    /// </summary>

    [ContextMenu("Print all buff")]
    void DEBUG_buffList()
    {
        Debug.Log($"{allBuffList.PrintAllBuff()}");
    }
    public void GetBlueHealth(int value)
    {
        blueHealth += value;
    }
    public void ClearBlueHealth()
    {
        blueHealth = 0;
    }
    public void ReceiveDamage(int damage)
    {
        damage = (int)Math.Round(CurrentDamageReductionRate*damage);
        DirectlyReceiveDamage(damage);
    }
    void DirectlyReceiveDamage(int damage)
    {
        if (blueHealth > 0)
        {
            blueHealth-=damage;
            blueHealth = Math.Max(blueHealth,0);
            return;
        }
        health -= damage;
    }
    public void ReceiveHeal(int heal)
    {
        DirectlyReceiveHeal(heal);
    }
    void DirectlyReceiveHeal(int heal)
    {
        health+=heal;
        health = Math.Min(health,maxHealth);
    }

    public void StateUpdate()
    {
        BuffListUpdate();
    }
    void BuffListUpdate()
    {
        allBuffList.StateUpdate();
        allBuffList.DeleteTimeoutBuff();

    }
    public void AddBuffState(BuffState buffState)
    {
        buffState.ExecuteOnBuffAdded();
        allBuffList.AddBuffState(buffState);
    }
    void Update()
    {

    }
}
