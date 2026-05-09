using System;
using System.Collections.Generic;
using UnityEngine;

public class CarMovement : MonoBehaviour
{
    [SerializeField] float speed = 5;
    [SerializeField] float angularVelocity = 30;//度/sec
    [SerializeField] List<CarPoint> positionList = new List<CarPoint>();
    [SerializeField] int positionListPointer = 0;
    CarPoint currentCarPoint;
    Vector3 currentTargetPosition
    {
        get
        {
            if (currentCarPoint == null) { return transform.position; }
            else { return currentCarPoint.transform.position; }
        }
    }
    [SerializeField] bool isLoop = true;

    [SerializeField] bool isStop;
    [SerializeField] public bool isDetectTeammate;


    

    void Start()
    {
        currentCarPoint = positionList[positionListPointer % positionList.Count];
    }
    void Update()
    {
        StateUpdate();
    }
    void StateUpdate()
    {
        if (positionListPointer >= positionList.Count || isStop || !isDetectTeammate) { return; }
        Vector3 targetFacing = FacingDirection();
        double angle = transform.rotation.eulerAngles.z/180*Math.PI;
        Vector3 facing = new Vector2((float)Math.Cos(angle), (float)Math.Sin(angle)).normalized;

        if (facing == targetFacing) { }
        else if (Vector3.Angle(targetFacing,facing) > angularVelocity * Time.deltaTime)
        {

            int direct = Vector3.Angle(targetFacing, facing) > 180 ? 1 : -1;
            Debug.Log($"rota:{direct*angularVelocity * Time.deltaTime} ang{Vector3.Angle(targetFacing,facing)}");
            transform.Rotate(0, 0, angularVelocity * Time.deltaTime*direct);
        }
        else
        {
            transform.rotation = Quaternion.Euler(0, 0, (float)(Math.Atan2(targetFacing.y, targetFacing.x) * 180 / Math.PI));
        }
        angle = transform.rotation.eulerAngles.z/180*Math.PI;
        facing = new Vector2((float)Math.Cos(angle), (float)Math.Sin(angle)).normalized;
        transform.position += facing * speed * Time.deltaTime;
    }
    Vector3 FacingDirection()
    {
        return (currentTargetPosition - transform.position).normalized;
    }
    void SetNextTargetPosition()
    {
        if (positionListPointer < positionList.Count - 1 || isLoop)
        {
            positionListPointer++;
            positionListPointer %= positionList.Count;
            currentCarPoint = positionList[positionListPointer];
        }
        else
        {
            currentCarPoint = null;
            isStop = true;
        }
    }
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent<CarPoint>(out var value) && value==currentCarPoint)
        {
            SetNextTargetPosition();
        }
    }
}
