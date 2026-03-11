using UnityEngine;

public class Player : MonoBehaviour
{
    public GameObject[] weapons; // 儲存所有武器
    private int currentWeaponIndex = 0; // 當前武器索引
    public float speed = 0.01f;
    void SwitchWeapon(int index)
    {
        // 隱藏所有武器
        foreach (GameObject weapon in weapons)
        {
            weapon.SetActive(false);
        }
        // 啟用目標武器
        weapons[index].SetActive(true);
        currentWeaponIndex = index;
    }
    void WeaponFaceToMouse()
    {
        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        // 2. 計算滑鼠與武器的向量差
        Vector2 direction = new Vector2(
            mousePos.x - transform.position.x,
            mousePos.y - transform.position.y
        );

        float angle = Mathf.Atan2(direction.y, direction.x);

 
        foreach (GameObject weapon in weapons)
        {
            weapon.transform.position = new Vector3((float)(transform.position.x + 0.7 * Mathf.Cos(angle)), (float)(transform.position.y + 0.7 * Mathf.Sin(angle)), 0);
            weapon.transform.rotation = Quaternion.Euler(0, 0, angle);
        }

        // 5. 根據角色朝向翻轉武器 (避免倒立)
        Vector3 playerScale = transform.localScale;
        if (playerScale.x < 0)
        {
            foreach (GameObject weapon in weapons)
            {
                weapon.transform.localScale = new Vector3(1, -1, 1); 
            }
        }
        else
        {
            foreach (GameObject weapon in weapons)
            {
                weapon.transform.localScale = new Vector3(1, 1, 1);
            }
        }
    }


    private void movement()//方法
    {   
        if (Input.GetKey("d") )//輸入.來自鍵盤(“d”)
        {
            this.gameObject.transform.position += new Vector3(speed, 0, 0);
        }  //此類別.這個物件.座標系統.位置(為一個向量值x,y,z)+=這個向量

        //向左走
        if (Input.GetKey("a") )
        {
            this.gameObject.transform.position -= new Vector3(speed, 0, 0);
        }
        //向上走
        if (Input.GetKey("w") )
        {
            this.gameObject.transform.position += new Vector3(0, speed, 0);
        }
        //向下走
        if (Input.GetKey("s") )
        {
            this.gameObject.transform.position -= new Vector3(0, speed, 0);
        }

    }
    void faceMouse()
    {
        Vector3 mousePosition = Input.mousePosition;
        mousePosition = Camera.main.ScreenToWorldPoint(mousePosition);
        Vector2 faceDirection = new Vector2(
            mousePosition.x - transform.position.x,
            mousePosition.y - transform.position.y
            );
        transform.up = faceDirection;
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        SwitchWeapon(0);
    }

    // Update is called once per frame
    void Update()
    {
        WeaponFaceToMouse();
        if (Input.GetAxis("Mouse ScrollWheel") > 0f)
        {
            SwitchWeapon((currentWeaponIndex + 1) % weapons.Length);
        }
        if (Input.GetAxis("Mouse ScrollWheel") < 0f)
        {
            SwitchWeapon((currentWeaponIndex - 1 + weapons.Length) % weapons.Length);
        }
        
        if (Input.GetKeyDown(KeyCode.Alpha1)) SwitchWeapon(0);
        if (Input.GetKeyDown(KeyCode.Alpha2)) SwitchWeapon(1);
        if (Input.GetKeyDown(KeyCode.Alpha3)) SwitchWeapon(2);
        movement();
        faceMouse();
    }
}
