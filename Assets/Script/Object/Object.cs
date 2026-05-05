using UnityEngine;

public abstract class OWObject : MonoBehaviour
{
    void Update()
    {
        StateUpdate();
    }
    public virtual void StateUpdate() { }
}
