using UnityEngine;

public class Door : Building
{
    [SerializeField] DoorState doorState = DoorState.open;
    [SerializeField] DoorPart doorOpen;
    [SerializeField] DoorPart doorClose;
    enum DoorState
    {
        open,
        close,
    }
    void Start()
    {
        UpdateDoor();
    }
    public override void Interact()
    {
        if (doorState == DoorState.open)
        {
            doorState = DoorState.close;
        }
        else if (doorState == DoorState.close)
        {
            doorState = DoorState.open;
        }
        UpdateDoor();
    }
    void UpdateDoor()
    {
        if (doorState == DoorState.open)
        {
            doorOpen.gameObject.SetActive(true);
            doorClose.gameObject.SetActive(false);
        }
        else if (doorState == DoorState.close)
        {
            doorOpen.gameObject.SetActive(false);
            doorClose.gameObject.SetActive(true);
        }
    }
}
