using UnityEngine;

public abstract class Item : MonoBehaviour
{
    [SerializeField] public Charater ownerCharater;
    public bool isHolding = false;
    public abstract void UseItem();
    public abstract void UseItem2();
    public abstract void ContinueUseItem();
    public abstract void ContinueUseItem2();
    public abstract void StateUpdate();
}
