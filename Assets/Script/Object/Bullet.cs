using System;
using UnityEngine;

public abstract class Bullet : OWObject
{
    [SerializeField] protected float speed;
    [SerializeField] protected int damage;
    public float lifeTimer;
    public GameObject attacker;

    public override void StateUpdate()
    {
        float angle = transform.rotation.eulerAngles.z;
        // Vector3 vector3 = (new Vector2((float)Math.Cos(angle / 180 * Math.PI), (float)Math.Sin(angle / 180 * Math.PI))).normalized * speed * Time.deltaTime;
        Vector3 vector3 = (new Vector2((float)Math.Cos(angle/180*Math.PI),(float)Math.Sin(angle/180*Math.PI))).normalized * speed * Time.deltaTime;

        this.transform.position += vector3;
        // Debug.Log($"vec:{vector3} ang:{transform.rotation.eulerAngles}");
        lifeTimer -= Time.deltaTime;
        if(lifeTimer<=0)
        {
            Destroy(gameObject);
        }
    }
    public abstract DamageInfo BuildDamageInfo();
    
}
