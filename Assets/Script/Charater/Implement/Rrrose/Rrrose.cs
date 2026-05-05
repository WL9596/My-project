using UnityEngine;
using UnityEngine.UIElements;

public class Rrrose : Charater
{
    enum HookState
    {
        flying,
        hit,
        pull
    }
    [Header("Skill 1")]
    [SerializeField] Animator hookAnimator;
    [SerializeField] HookCollider hookCollider;
    [SerializeField] HookState hookState;
    [SerializeField] GameObject hookedObj;
    FrozenBuff frozenBuff;
    HookedByRrroseBuff hookedByRrroseBuff;
    Vector3 lastHookTopPosition;
    float flyingTimeRate;

    [Header("Skill 3")]
    [SerializeField] GameObject healthCircleModel;
    [SerializeField] RrroseHealthCircle healthCircle;
    [SerializeField] float healthCircleTimer;
    [SerializeField] float healCircleContinueTime = 5;
    [SerializeField] int gainBlueHealth = 100;

    [Header("Ultimate Skill")]
    [SerializeField] int waveCount = 4;
    [SerializeField] float waveTriggerTime = 1;
    [SerializeField] float waveWidth = 1;
    [SerializeField] float waveFrozenTime = 3;
    [SerializeField] GameObject rrroseWaveModel;

    public override void UseSkill1()
    {
        if (!IsAbleUseSkill1()) { return; }
        skillEnum = skillEnum | SkillEnum.skill1;
        skill1CooldownTimer = skill1Cooldown;
        hookAnimator.gameObject.SetActive(true);
        hookState = HookState.flying;
        hookAnimator.SetTrigger(hookState.ToString());
        frozenBuff = new FrozenBuff();
        property.AddBuffState(frozenBuff);
    }
    protected override void BreakSkill1()
    {
        if(skillEnum.HasFlag(SkillEnum.skill1))
        {
            Debug.Log($"remove skill1");
            skillEnum &= ~SkillEnum.skill1; //移除skill1
            hookAnimator.gameObject.SetActive(false);
            frozenBuff?.RemoveState();
            hookedByRrroseBuff?.RemoveState();
            frozenBuff = null;
            hookedByRrroseBuff = null;
        }
    }
    protected override void Skill1StateUpdate()
    {
        AnimatorStateInfo stateInfo = hookAnimator.GetCurrentAnimatorStateInfo(0);
        if (stateInfo.IsName(HookState.flying.ToString()) && stateInfo.normalizedTime >= 1.0f)
        {
            BreakSkill1();
            skill1CooldownTimer=0;
        }
        if(stateInfo.IsName(HookState.pull.ToString()))
        {

            if (stateInfo.normalizedTime >= 0.9f)
            {
                BreakSkill1();
            }
            else
            {
                TranslatePosition(-(hookCollider.transform.position-lastHookTopPosition));
                lastHookTopPosition = hookCollider.transform.position;
            }
        }
        if(stateInfo.IsName(HookState.hit.ToString()))
        {
            hookState = HookState.pull; 
            hookAnimator.Play(HookState.pull.ToString(),0,1-flyingTimeRate);
        }
    }
    public void HookColliderEnter(Collider2D collision)
    {
        if(skillEnum.HasFlag(SkillEnum.skill1) 
        && hookState == HookState.flying
        && collision.gameObject != gameObject 
        && (collision.gameObject.layer == LayerMask.NameToLayer("Build")||collision.gameObject.layer == LayerMask.NameToLayer("Charater")))
        {
            lastHookTopPosition = hookCollider.transform.position;
            AnimatorStateInfo stateInfo = hookAnimator.GetCurrentAnimatorStateInfo(0);
            flyingTimeRate = stateInfo.normalizedTime;
            hookedObj = collision.gameObject;
            hookState = HookState.hit;
            hookAnimator.SetTrigger(hookState.ToString());
            if(collision.TryGetComponent<Charater>(out var value))
            {
                hookedByRrroseBuff = new HookedByRrroseBuff();
                value.AddBuffState(hookedByRrroseBuff);
            }
        }
    }
    protected override bool IsAbleUseSkill1()
    {
        return base.IsAbleUseSkill1() && !skillEnum.HasFlag(SkillEnum.skill3)&& !skillEnum.HasFlag(SkillEnum.ultimateSkill);
    }

    //沒有的技能就空著
    public override void UseSkill2() { }
    protected override void Skill2StateUpdate() { }

    public override void UseSkill3()
    {
        if(skillEnum.HasFlag(SkillEnum.skill3))
        {
            BreakSkill3();
        }
        else
        {
            BreakSkill1();
            skillEnum = skillEnum | SkillEnum.skill3;
            healthCircle = Instantiate(healthCircleModel).GetComponent<RrroseHealthCircle>();
            healthCircle.teamTag = teamTag;
            healthCircle.transform.position = transform.position;
            frozenBuff = new FrozenBuff();
            property.AddBuffState(frozenBuff);
            healthCircleTimer = healCircleContinueTime;
            property.GetBlueHealth(gainBlueHealth);
        }
    }
    protected override void BreakSkill3()
    {
        if (!skillEnum.HasFlag(SkillEnum.skill3)) { return; }
        Destroy(healthCircle?.gameObject);
        frozenBuff.RemoveState();
        frozenBuff = null;
        skillEnum = skillEnum &~ SkillEnum.skill3;
        property.ClearBlueHealth();
        skill3CooldownTimer = skill3Cooldown;
    }
    protected override bool IsAbleUseSkill3()
    {
        return (base.IsAbleUseSkill3());
    }
    protected override void Skill3StateUpdate()
    {
        if(healthCircleTimer>0)
        {
            healthCircleTimer-=Time.deltaTime;
        }
        if(healthCircleTimer<=0)
        {
            BreakSkill3();
        }
    }

    public override void UseUltimateSkill()
    {
        if (!IsAbleUseUltimateSkill()) { return; }
        skillEnum = skillEnum | SkillEnum.ultimateSkill;
        ultimateSkillCooldownTimer = ultimateSkillCooldown;
        frozenBuff = new FrozenBuff();
        property.AddBuffState(frozenBuff);
        animationController.Animator.SetTrigger("ultimateMove");
    }
    protected override void UltimateSkillStateUpdate()
    {
        AnimatorStateInfo stateInfo = animationController.Animator.GetCurrentAnimatorStateInfo(0);
        if (stateInfo.IsName("ultimateMove") && stateInfo.normalizedTime >= 1.0f)
        {
            SummonUltimateAttackArea();
            animationController.Animator.SetTrigger("rrroseMove");
            BreakUltimateSkill();
        }
    }
    void SummonUltimateAttackArea()
    {
        for(int i=0;i<waveCount;i++)
        {
            RrroseWave wave = Instantiate(rrroseWaveModel).GetComponent<RrroseWave>();
            wave.transform.rotation = transform.rotation;
            wave.transform.position = transform.position + (Vector3)FacingVector2() * (i + 0.5f) * waveWidth;
            wave.transform.localScale = new Vector3(waveWidth, wave.transform.localScale.y, wave.transform.localScale.z);
            wave.attackCharater = this;
            wave.frozenTime = waveFrozenTime;
            wave.SetTimer(i * waveTriggerTime, waveTriggerTime);
        }
    }
    protected override bool IsAbleUseUltimateSkill()
    {
        return base.IsAbleUseUltimateSkill() && !skillEnum.HasFlag(SkillEnum.skill1);
    }
    protected override void BreakUltimateSkill()
    {
        if (!skillEnum.HasFlag(SkillEnum.ultimateSkill)) { return; }
        frozenBuff.RemoveState();
        frozenBuff = null;
        skillEnum = skillEnum &~ SkillEnum.ultimateSkill;
        ultimateSkillCooldownTimer = ultimateSkillCooldown;
    }
    public override void OnBulletHit(Vector3 hitPosition)
    {
        
    }
}
