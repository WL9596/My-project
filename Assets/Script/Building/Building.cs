using UnityEngine;

public class Building : MonoBehaviour
{
    [SerializeField] bool isInteractable = false;
    public bool IsInteractable => isInteractable;
    public virtual void Interact() { }
}
