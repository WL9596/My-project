using UnityEngine;
using System.Collections.Generic;

public class FrozenBuff : BuffState
{
    public FrozenBuff()
    {
        propertyEnums = new HashSet<PropertyEnum>{PropertyEnum.speed,PropertyEnum.rotate};
        timer = -1;
    }
    public override bool GetIsEnableRotate(bool isEnableRotate)
    {
        return false;
    }
    public override float GetSpeed(float speed)
    {
        return 0;
    }
}
