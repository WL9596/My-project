using UnityEngine;

public class CharaterInputSystem : MonoBehaviour
{
    [SerializeField] Charater charater;
    void Update()
    {
        MoveInput();
        FacingInput();
        ClickInput();
    }
    void ClickInput()
    {
        if (Input.GetMouseButtonDown(0))
        {
            charater.ClickUseItem();
        }
        if (Input.GetMouseButton(0))
        {
            charater.ContinueUseItem();
        }
        if (Input.GetMouseButtonDown(1))
        {
            charater.ClickUseItem2();
        }
        if (Input.GetMouseButton(1))
        {
            charater.ContinueUseItem2();
        }

    }
    void MoveInput()
    {
        int horizontalInputCode = 0;
        if (Input.GetKey(KeyCode.A)) { horizontalInputCode--; }
        if (Input.GetKey(KeyCode.D)) { horizontalInputCode++; }
        int verticalInputCode = 0;
        if (Input.GetKey(KeyCode.S)) { verticalInputCode--; }
        if (Input.GetKey(KeyCode.W)) { verticalInputCode++; }
        charater.Move(new Vector2(horizontalInputCode, verticalInputCode));
    }
    void FacingInput()
    {
        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector2 direction = new Vector2(mousePos.x - charater.transform.position.x, mousePos.y - charater.transform.position.y);
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        charater.Facing(angle);
    }
}
