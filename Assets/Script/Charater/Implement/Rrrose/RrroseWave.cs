using System.Collections.Generic;
using UnityEngine;

public class RrroseWave : OWObject
{
    public Charater attackCharater;
    public float frozenTime;
    [SerializeField] Animator animator;
    [SerializeField] float waitTime;
    [SerializeField] float triggerTime;
    List<IHitbox> collisionList = new List<IHitbox>();
    bool isTrigger = false;
    public void SetTimer(float waitTime, float triggerTime)
    {
        this.waitTime = waitTime;
        this.triggerTime = triggerTime;
        if (waitTime <= 0) { animator.SetTrigger("start");}
    }
    
    public override void StateUpdate()
    {
        if(isTrigger)
        {
            foreach(IHitbox hitbox in collisionList)
            {
                DamageInfo damageInfo = new DamageInfo();
                damageInfo.buffInfoList.Add(new FrozenBuffInfo(frozenTime));
                hitbox.ReceiveDamageInfo(damageInfo);
                Debug.LogWarning($"attack:{hitbox}");
            }
            Destroy(gameObject);
        }
        if (triggerTime > 0 && waitTime <= 0)
        {
            triggerTime -= Time.deltaTime;
            if (triggerTime <= 0)
            {
                isTrigger = true;
            }
        }
        if (waitTime > 0)
        {
            waitTime -= Time.deltaTime;
            if (waitTime <= 0)
            {
                animator.SetTrigger("start");
                
            }
        }

    }
    void OnTriggerEnter2D(Collider2D collision)
    {
        if((collision.gameObject != attackCharater.gameObject
            && (collision.gameObject.layer == LayerMask.NameToLayer("Build") || collision.gameObject.layer == LayerMask.NameToLayer("Charater"))
            && collision.TryGetComponent<IHitbox>(out var value)))
        {
            collisionList.Add(value);
        }
    }
    void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.TryGetComponent<IHitbox>(out var value))
        {
            int amount = collisionList.Count;
            for(int i = amount-1;i>=0;i--)
            {
                if(collisionList[i]==value)
                {
                    collisionList.RemoveAt(i);
                }
            }
        }
    }
}
