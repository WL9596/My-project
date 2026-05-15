using UnityEngine;

public class DoorPart : Building
{
    [SerializeField] Door door;
    public override void Interact()
    {
        door.Interact();
    }
}
