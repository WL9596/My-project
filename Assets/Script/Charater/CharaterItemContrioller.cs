using System;
using System.Collections.Generic;
using UnityEngine;

public class CharaterItemContrioller : MonoBehaviour, ICharaterComponent
{
    [SerializeField] List<Item> itemList = new List<Item>();
    [SerializeField] Item currentHoldingItem;
    [SerializeField] bool isEnableSwitchHoldingItem = true;

    public void StateUpdate()
    {
        foreach(Item item in itemList)
        {
            item.StateUpdate();
        }
    }
    public void UseItem()
    {
        currentHoldingItem.UseItem();
    }
    public void ContinueUseItem()
    {
        currentHoldingItem.ContinueUseItem();
    }
    public void UseItem2()
    {
        currentHoldingItem.UseItem2();
    }
    public void ContinueUseItem2()
    {
        currentHoldingItem.ContinueUseItem2();
    }
}
