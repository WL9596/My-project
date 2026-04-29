using UnityEngine;

public class TEST_Charater : Charater
{
    

    public override void UseSkill1(){Debug.Log("UseSkill1");}
    public override void UseSkill2(){Debug.Log("UseSkill2");}
    public override void UseSkill3(){Debug.Log("UseSkill3");}
    public override void UseUltimateSkill(){Debug.Log("UseUltimateSkill");}

    protected override void Skill1StateUpdate()
    {
        throw new System.NotImplementedException();
    }

    protected override void Skill2StateUpdate()
    {
        throw new System.NotImplementedException();
    }

    protected override void Skill3StateUpdate()
    {
        throw new System.NotImplementedException();
    }

    protected override void UltimateSkillStateUpdate()
    {
        throw new System.NotImplementedException();
    }
}
