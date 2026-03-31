using UnityEngine;
using UnityEngine.InputSystem;

public class Charater : MonoBehaviour
{
    [Header("Component")]
    [SerializeField] CharaterAnimationController animationController;
    [SerializeField] CharaterHitBox hitbox;
    [SerializeField] CharaterItemContrioller itemController;
    [SerializeField] CharaterState state;

    public void Move(Vector2 controll)
    {
        state.Move(controll);
    }
    public void Facing(float rotation)
    {
        state.Facing(rotation);
    }
    public void UseItem()
    {
        itemController.UseItem();
    }
    public void UseItem2()
    {
        itemController.UseItem2();
    }

    void Update()
    {
        animationController.StateUpdate();
        hitbox.StateUpdate();
        itemController.StateUpdate();
        state.StateUpdate();
    }
}
