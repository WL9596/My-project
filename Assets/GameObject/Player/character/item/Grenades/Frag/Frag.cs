using UnityEngine;

public class Frag : item
{
    private bool inhand;
    public float speed = 1;
    public override void UseItem(float angle)
    {
        bool throwing = false;
        bool flying = false;
        if (flying)
        {
            this.gameObject.transform.position += (new Vector3((float)(speed * Mathf.Cos(angle)), (float)(speed * Mathf.Cos(angle)), 1));
        }
    }


    void Start()
    {
        inhand = true;
        this.gameObject.transform.localScale = new Vector3(0.3f, -1, 1);
    }
    void Throw(float angle)
    {
        bool throwing = false;
        bool flying = false;
        if (flying)
        {
            this.gameObject.transform.position += (new Vector3((float)(speed * Mathf.Cos(angle)), (float)(speed * Mathf.Cos(angle)), 1));
        }
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


        if (inhand)
        {
            // 5. 處理反轉 (若滑鼠在左邊，武器反轉以避免倒立)
            if (angle > 90 || angle < -90)
            {
                transform.localRotation = Quaternion.Euler(0, 0, angle + 90);
                this.gameObject.transform.localScale = new Vector3(0.1f, -1.5f, 1);

            }
            else
            {
                transform.localRotation = Quaternion.Euler(0, 0, angle - 90);
                this.gameObject.transform.localScale = new Vector3(0.1f, 1.5f, 1);
            }
            if (Input.GetKey(KeyCode.Mouse0))
            {
                float curang = angle;
                inhand = false;

            }
        }

    }
}

