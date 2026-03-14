using UnityEngine;

public class Rifle : MonoBehaviour
{
    void Start()
    {
        this.gameObject.transform.localScale = new Vector3(0.3f, -1, 1);
    }
    void Update()
    {
        // 1. 獲取滑鼠的世界位置
        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mousePos.z = 0f; // 2D 遊戲中，確保 Z 軸為 0 [6, 8]

        // 2. 計算方向向量 (滑鼠位置 - 武器位置)
        Vector2 direction = mousePos - transform.position;

        // 3. 計算角度 (使用 Atan2 計算弧度，再轉換為角度) [6]
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;

        // 4. 旋轉父物件 (WeaponPivot)
        transform.rotation = Quaternion.Euler(0, 0, angle);

        // 5. 處理反轉 (若滑鼠在左邊，武器反轉以避免倒立)
        if (angle > 90 || angle < -90)
        {
            transform.localRotation = Quaternion.Euler(0, 0, angle + 90);
            this.gameObject.transform.localScale = new Vector3(0.3f, -1, 1);

        }
        else
        {
            transform.localRotation = Quaternion.Euler(0, 0, angle - 90);
            this.gameObject.transform.localScale = new Vector3(0.3f, 1, 1);
        }
    }
}
