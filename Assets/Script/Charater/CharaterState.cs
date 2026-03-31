using System;
using System.Collections.Generic;
using UnityEngine;

public class CharaterState : MonoBehaviour, CharaterComponent
{
    [SerializeField] Transform charaterTransform;
    [Header("State")]
    [SerializeField] int health;
    public int Health => health;
    [SerializeField] float speed = 0.01f;
    public float BaseSpeed => speed;
    public float CurrentSpeed => buffList.GetSpeed(speed);
    BuffList buffList = new BuffList();


    public void Move(Vector2 controll)
    {
        if (controll.x == 0 && controll.y == 0) { return; }
        Vector2 movement = controll.normalized * (buffList.GetSpeed(speed) * Time.deltaTime);
        // Debug.Log($"Time:{Time.time} | movement:{movement} | normalized:{controll.normalized} |controll:{controll} | speed:{buffList.GetSpeed(speed)} | deltaTime:{Time.deltaTime}");
        TranslatePosition(movement);
    }
    public void TranslatePosition(Vector2 vector2)
    {
        //charaterTransform.transform.position = charaterTransform.transform.position + new Vector3(vector2.x, vector2.y, 0);
        Vector2 direction = vector2.normalized;
        RaycastHit2D hit = Physics2D.Raycast(charaterTransform.position, direction, vector2.magnitude+0.5f, LayerMask.GetMask("Build"));
        Debug.DrawRay(charaterTransform.position, vector2, Color.red, 1);
        Debug.Log($"pos:{charaterTransform.position} | vec:{vector2}");


        if (hit.collider != null)//未來碰撞架構搭建完後再更改判定
        {
            charaterTransform.position = hit.point - direction * 0.5f;
        }
        else
        {
            charaterTransform.position = (Vector2)charaterTransform.position + vector2;
        }
    }
    public void Facing(float rotation)
    {
        charaterTransform.transform.rotation = Quaternion.Euler(new Vector3(0,0,rotation));
    }

    public void StateUpdate()
    {
        BuffListUpdate();
    }
    void BuffListUpdate()
    {
        buffList.StateUpdate();
    }
    void Update()
    {
        
        // float angle = charaterTransform.transform.rotation.eulerAngles.z;
        // Vector2 movement = (new Vector2((float)Math.Cos(angle/180*Math.PI), (float)Math.Sin(angle/180*Math.PI))).normalized;
        // Debug.DrawRay(charaterTransform.position, movement, Color.black);
        // RaycastHit2D hit = Physics2D.Raycast(charaterTransform.position, movement, 1, LayerMask.GetMask("Build"));
        // if (hit.collider != null)
        // {
        //     Debug.Log($"touch : {hit.collider}");
        //     // charaterTransform.position = hit.point - direction * 0.1f;
        // }
        // else
        // {
        //     Debug.Log($"untouch");

        // }
    }
}
