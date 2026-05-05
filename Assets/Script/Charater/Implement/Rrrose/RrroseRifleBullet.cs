using UnityEngine;

public class RrroseRifleBullet : Bullet
{
    public Charater attackCharater;//
    public override DamageInfo BuildDamageInfo()
    {
        DamageInfo damageInfo = new DamageInfo();
        damageInfo.damage = damage;
        return damageInfo;
    }
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject != attacker 
        && (collision.gameObject.layer == LayerMask.NameToLayer("Build")||collision.gameObject.layer == LayerMask.NameToLayer("Charater")))
        {
            // Debug.Log($"collision:{collision.gameObject} attacker:{attacker} bool:{collision.gameObject == attacker}");
            if(collision.TryGetComponent<IHitbox>(out var value))
            {
                value.ReceiveDamageInfo(BuildDamageInfo());
            }
            
            Destroy(gameObject);
        }
    }
    void OnCllisionEnter2D(Collision2D collision)
    {
        
    }
}
