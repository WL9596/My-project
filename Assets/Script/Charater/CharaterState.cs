using System;
using System.Collections.Generic;
using UnityEngine;

public class CharaterProperty : MonoBehaviour, CharaterComponent
{
    [SerializeField] Transform charaterTransform;
    public Transform CharaterTransform => charaterTransform;
    [Header("State")]
    [SerializeField] int health;
    public int Health => health;
    [SerializeField] float speed = 0.01f;
    public float BaseSpeed => speed;
    public float CurrentSpeed => buffList.GetSpeed(speed);
    BuffList buffList = new BuffList();
    public BuffList PropertyBuffList => buffList;


    

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

    }
}
