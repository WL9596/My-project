using UnityEngine;
using UnityEngine.InputSystem;

public class Charater : MonoBehaviour
{
    [Header("Component")]
    [SerializeField] CharaterAnimationController animationController;
    [SerializeField] CharaterHitBox hitbox;
    [SerializeField] CharaterItemContrioller itemController;
    [SerializeField] CharaterProperty property;

    public void Move(Vector2 controll)
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
    public void Facing(float rotation)
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
    // public abstract void UseSkill1();
    // public abstract void UseSkill2();
    // public abstract void UseSkill3();
    // public abstract void UseUltimateSkill();


    void Update()
    {
        animationController.StateUpdate();
        hitbox.StateUpdate();
        itemController.StateUpdate();
        property.StateUpdate();
    }
}
