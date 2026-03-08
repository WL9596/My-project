using UnityEngine;

public class Player : MonoBehaviour
{
    public float speed = 0.01f;    

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
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        movement();
    }
}
