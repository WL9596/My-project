using UnityEngine;

public class RrroseRifle : Item
{
    [SerializeField] GameObject rrroseRifleBulletModel;
    [SerializeField] float rifleInterval = 0.2f;
    [SerializeField] float rifleTimer = 0;


    public override void ContinueUseItem2() { }
    public override void UseItem() { }
    public override void UseItem2() { }



    public override void ContinueUseItem()
    {
        if (rifleTimer <= 0)
        {
            Shoot();
            rifleTimer = rifleInterval;
        }
    }
    void Shoot()
    {
        RrroseRifleBullet rifleBullet = Instantiate(rrroseRifleBulletModel).GetComponent<RrroseRifleBullet>();
        rifleBullet.transform.rotation = transform.rotation;
        rifleBullet.transform.position = transform.position;
        rifleBullet.attacker = ownerCharater.gameObject;
        rifleBullet.attackCharater = ownerCharater;
    }

    
    public override void StateUpdate()
    {
        if (rifleTimer > 0) { rifleTimer -= Time.deltaTime; }
    }
}
