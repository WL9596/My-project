using UnityEngine;
using System.Collections.Generic;

public class HookedByRrroseBuff : BuffState
{
    public HookedByRrroseBuff()
    {
        propertyEnums = new HashSet<PropertyEnum>{PropertyEnum.speed};
        timer = -1;
    }
    public override float GetSpeed(float speed)
    {
        return 0;
    }
}
