using UnityEngine;

public class CharaterAnimationController : MonoBehaviour, ICharaterComponent
{
    [SerializeField] Animator animator;
    public Animator Animator => animator;
    public void StateUpdate()
    {

    }
}
