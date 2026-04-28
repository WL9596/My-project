using UnityEngine;

public class RrroseRifle : Item
{
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
        RrroseRifleBullet rifleBullet = Instantiate(PrefabCollection.Instance.rrroseRifleBullet).GetComponent<RrroseRifleBullet>();
        rifleBullet.transform.rotation = transform.rotation;
        rifleBullet.transform.position = transform.position;
        rifleBullet.attacker = ownerCharater.gameObject;
    }

    
    public override void StateUpdate()
    {
        if (rifleTimer > 0) { rifleTimer -= Time.deltaTime; }
    }
}
