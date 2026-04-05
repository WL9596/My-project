using UnityEngine;
using UnityEngine.InputSystem;

public abstract class Charater : MonoBehaviour
{
    [Header("Component")]
    [SerializeField] protected CharaterAnimationController animationController;
    [SerializeField] protected CharaterHitBox hitbox;
    [SerializeField] protected CharaterItemContrioller itemController;
    [SerializeField] protected CharaterProperty property;

    public virtual void Move(Vector2 controll)
    {
        if (controll.x == 0 && controll.y == 0) { return; }
        Vector2 movement = controll.normalized * (property.CurrentSpeed * Time.deltaTime);
        TranslatePosition(movement);
    }
    public void TranslatePosition(Vector2 vector2)
    {
        Vector2 direction = vector2.normalized;
        RaycastHit2D hit = Physics2D.Raycast(property.CharaterTransform.position, direction, vector2.magnitude+0.5f, LayerMask.GetMask("Build"));
        Debug.DrawRay(property.CharaterTransform.position, -vector2, Color.red, 1);//軌跡

        //未來碰撞架構搭建完後再更改判定
        if (hit.collider != null)
        {
            property.CharaterTransform.position = hit.point - direction * 0.5f;
        }
        else
        {
            property.CharaterTransform.position = (Vector2)property.CharaterTransform.position + vector2;
        }
    }
    public virtual void Facing(float rotation)
    {
        property.CharaterTransform.rotation = Quaternion.Euler(new Vector3(0,0,rotation));
    }
    public virtual void ClickUseItem()
    {
        itemController.UseItem();
    }
    public virtual void ContinueUseItem()
    {
        itemController.ContinueUseItem();
    }
    public virtual void ClickUseItem2()
    {
        itemController.UseItem2();
    }
    public virtual void ContinueUseItem2()
    {
        itemController.ContinueUseItem2();
    }
    public abstract void UseSkill1();
    public abstract void UseSkill2();
    public abstract void UseSkill3();
    public abstract void UseUltimateSkill();
    public void ReceiveDamageInfo(DamageInfo damageInfo)
    {
        //BUFF處裡的位置
        property.ReceiveDamage(damageInfo.damage);
    }
    

    /// <summary>
    /// TODO
    /// 未來將會有一個物件來統一管理所有場上物體的StateUpdate順序，目前先掛在角色的Update身上
    /// </summary>

    void Update()
    {
        StateUpdate();
    }
    public void StateUpdate()
    {
        animationController.StateUpdate();
        hitbox.StateUpdate();
        itemController.StateUpdate();
        property.StateUpdate();
    }
}
