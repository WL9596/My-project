using UnityEngine;

public class ItemTest : Item
{
    public override void UseItem()
    {
        Debug.Log("UseItem");
    }

    public override void UseItem2()
    {
        Debug.Log("UseItem2");
    }
}
