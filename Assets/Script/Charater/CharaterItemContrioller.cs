using System;
using System.Collections.Generic;
using UnityEngine;

public class CharaterItemContrioller : MonoBehaviour, CharaterComponent
{
    [SerializeField] List<Item> itemList = new List<Item>();
    [SerializeField] Item currentHoldingItem;
    [SerializeField] bool isEnableSwitchHoldingItem = true;

    public void StateUpdate()
    {

    }
    public void UseItem()
    {
        currentHoldingItem.UseItem();
    }
    public void UseItem2()
    {
        currentHoldingItem.UseItem2();
    }
}
