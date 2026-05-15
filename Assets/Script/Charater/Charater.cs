using System;
using UnityEngine;
using UnityEngine.InputSystem;

public abstract class Charater : MonoBehaviour
{
    [Header("Component")]
    [SerializeField] protected CharaterAnimationController animationController;
    [SerializeField] protected CharaterHitBox hitbox;
    [SerializeField] protected CharaterItemContrioller itemController;
    [SerializeField] protected CharaterProperty property;
    [SerializeField] protected CharaterBuildingInteract buildingInteract;
    public CharaterProperty Property => property;

    [Header("Team tag")]
    [SerializeField] protected int teamTag = 0;
    public int TeamTag => teamTag;

    [Header("Skill State")]
    [SerializeField] protected SkillEnum skillEnum = SkillEnum.non;
    [SerializeField] protected float skill1Cooldown;
    [SerializeField] protected float skill1CooldownTimer;
    [SerializeField] protected float skill2Cooldown;
    [SerializeField] protected float skill2CooldownTimer;
    [SerializeField] protected float skill3Cooldown;
    [SerializeField] protected float skill3CooldownTimer;
    [SerializeField] protected float ultimateSkillCooldown;
    [SerializeField] protected float ultimateSkillCooldownTimer;
    

    public void Respawn(Vector3 spawnPosition)
    {
        property.CharaterTransform.position = spawnPosition;
        property.ResetProperty();
    }
    public void AddBuffState(BuffState buffState)
    {
        property.AddBuffState(buffState);
    }
    public virtual void Move(Vector2 controll)
    {
        if (controll.x == 0 && controll.y == 0) { return; }
        Vector2 movement = controll.normalized * (property.CurrentSpeed * Time.deltaTime);
        TranslatePosition(movement);
    }
    public void TranslatePosition(Vector2 vector2)
    {
        Vector2 direction = vector2.normalized;
        RaycastHit2D hit = Physics2D.Raycast(property.CharaterTransform.position, direction, vector2.magnitude+0.5f, LayerMask.GetMask("Build"));
        Debug.DrawRay(property.CharaterTransform.position, -vector2, Color.red, 1);//軌跡

        //未來碰撞架構搭建完後再更改判定
        if (hit.collider != null)
        {
            property.CharaterTransform.position = hit.point - direction * 0.5f;
        }
        else
        {
            property.CharaterTransform.position = (Vector2)property.CharaterTransform.position + vector2;
        }
    }
    public virtual void Facing(float rotation)
    {
        if (!property.CurrentIsEnableRotation) { return; }
        property.CharaterTransform.rotation = Quaternion.Euler(new Vector3(0, 0, rotation));
    }
    protected Vector2 FacingVector2()
    {
        double angle = property.CharaterTransform.rotation.eulerAngles.z / 180 * Math.PI;
        return new Vector2((float)Math.Cos(angle), (float)Math.Sin(angle));
    }
    public void BuildingInteract()
    {
        buildingInteract.TryInteract();
    }
    public virtual void ClickUseItem()
    {
        itemController.UseItem();
    }
    public virtual void ContinueUseItem()
    {
        itemController.ContinueUseItem();
    }
    public virtual void ClickUseItem2()
    {
        itemController.UseItem2();
    }
    public virtual void ContinueUseItem2()
    {
        itemController.ContinueUseItem2();
    }
    public abstract void UseSkill1();
    public abstract void UseSkill2();
    public abstract void UseSkill3();
    public abstract void UseUltimateSkill();
    protected abstract void Skill1StateUpdate();
    protected abstract void Skill2StateUpdate();
    protected abstract void Skill3StateUpdate();
    protected abstract void UltimateSkillStateUpdate();
    public void ReceiveDamageInfo(DamageInfo damageInfo)
    {
        foreach(DamageBuffInfo damageBuffInfo in damageInfo.buffInfoList)
        {
            BuffState buffState = damageBuffInfo.BuildBuffState();
            AddBuffState(buffState);
        }

        if(damageInfo.damage>=0)
        {
            property.ReceiveDamage(damageInfo.damage);
        }
        else
        {
            property.ReceiveHeal(-damageInfo.damage);
        }
    }
    protected virtual bool IsAbleUseSkill1() { return skill1CooldownTimer <= 0 && !skillEnum.HasFlag(SkillEnum.skill1); }
    protected virtual bool IsAbleUseSkill2() { return skill2CooldownTimer <= 0 && !skillEnum.HasFlag(SkillEnum.skill2); }
    protected virtual bool IsAbleUseSkill3() { return skill3CooldownTimer <= 0 && !skillEnum.HasFlag(SkillEnum.skill3); }
    protected virtual bool IsAbleUseUltimateSkill() { return ultimateSkillCooldownTimer <= 0 && !skillEnum.HasFlag(SkillEnum.ultimateSkill); }
    protected virtual void BreakSkill1(){}
    protected virtual void BreakSkill2(){}
    protected virtual void BreakSkill3(){}
    protected virtual void BreakUltimateSkill(){}

    public virtual void OnBulletHit(Vector3 hitPosition){}

    /// <summary>
    /// TODO
    /// 未來將會有一個物件來統一管理所有場上物體的StateUpdate順序，目前先掛在角色的Update身上
    /// </summary>

    void Update()
    {
        StateUpdate();
    }
    public virtual void StateUpdate()
    {
        animationController.StateUpdate();
        hitbox.StateUpdate();
        itemController.StateUpdate();
        property.StateUpdate();
        // Debug.Log($"skill:{skillEnum} hasFrag3:{skillEnum.HasFlag(SkillEnum.skill3)}");

        if (skill1CooldownTimer > 0) { skill1CooldownTimer -= Time.deltaTime; }
        if (skill2CooldownTimer > 0) { skill2CooldownTimer -= Time.deltaTime; }
        if (skill3CooldownTimer > 0) { skill3CooldownTimer -= Time.deltaTime; }
        if (ultimateSkillCooldownTimer > 0) { ultimateSkillCooldownTimer -= Time.deltaTime; }
        if (skillEnum.HasFlag(SkillEnum.skill1)) { Skill1StateUpdate(); }
        if (skillEnum.HasFlag(SkillEnum.skill2)) { Skill2StateUpdate(); }
        if (skillEnum.HasFlag(SkillEnum.skill3)) { Skill3StateUpdate(); }
        if (skillEnum.HasFlag(SkillEnum.ultimateSkill)) { UltimateSkillStateUpdate(); }
    }
}
