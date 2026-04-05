using UnityEngine;

public class CharaterHitBox : MonoBehaviour, ICharaterComponent, IHitbox
{
    [SerializeField] Charater charater;
    public void ReceiveDamageInfo(DamageInfo damageInfo)
    {
        
    }

    public void StateUpdate()
    {

    }
}
