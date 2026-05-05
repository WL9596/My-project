using UnityEngine;

public class HookCollider : MonoBehaviour
{
    [SerializeField] Rrrose rrrose;
    void OnTriggerEnter2D(Collider2D collision)
    {
        rrrose.HookColliderEnter(collision);
    }
}
