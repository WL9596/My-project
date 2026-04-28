using UnityEngine;

public class Rrrose : Charater
{
    enum HookState
    {
        flying,
        hit,
        pull
    }
    [SerializeField] Animator hookAnimator;
    [SerializeField] Collider2D hookCollider;
    [SerializeField] HookState hookState;
    [SerializeField] GameObject hookedObj;
    

    public override void UseSkill1()
    {
        if (!IsAbleUseSkill1()) { return; }
        skillEnum = skillEnum | SkillEnum.skill1;
        
        hookAnimator.gameObject.SetActive(true);
        hookState = HookState.flying;
        hookAnimator.SetTrigger(hookState.ToString());
        
    }
    public override void Skill1StateUpdate()
    {

        AnimatorStateInfo stateInfo = hookAnimator.GetCurrentAnimatorStateInfo(0);
        if (stateInfo.IsName(HookState.flying.ToString()) && stateInfo.normalizedTime >= 1.0f)
        {
            skillEnum &= ~SkillEnum.skill1; //移除skill1
            hookAnimator.gameObject.SetActive(false);
        }
    }
    public void HookColliderEnter(Collider2D collision)
    {
        if(skillEnum.HasFlag(SkillEnum.skill1) 
        && hookState == HookState.flying
        && collision.gameObject != gameObject 
        && (collision.gameObject.layer == LayerMask.NameToLayer("Build")||collision.gameObject.layer == LayerMask.NameToLayer("Charater")))
        {
            hookedObj = collision.gameObject;
            hookState = HookState.hit;
            hookAnimator.SetTrigger(hookState.ToString());
        }
    }


    //沒有的技能就空著
    public override void UseSkill2() { }
    public override void Skill2StateUpdate() { }

    public override void UseSkill3()
    {
        throw new System.NotImplementedException();
    }
    public override void Skill3StateUpdate()
    {
        throw new System.NotImplementedException();
    }

    public override void UseUltimateSkill()
    {
        throw new System.NotImplementedException();
    }
    public override void UltimateSkillStateUpdate()
    {
        throw new System.NotImplementedException();
    }
}
