using System.Collections.Generic;
using UnityEngine;

public class CarPoint : MonoBehaviour
{
    [SerializeField] SpriteRenderer pointSpriteRenderer;
    [SerializeField] List<SpawnPoint> spawnPointList = new List<SpawnPoint>();
    [SerializeField] bool isFirstPoint = false;//TODO 功能不完善

    void Awake()
    {
        PlayerSpawn.carPointList.Add(this);

    }
    void Start()
    {
        if(isFirstPoint)
        {
            PlayerSpawn.currentTriggerPoint = this;
            PlayerSpawn.CheckAllTriggerPoint();
        }
    }
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent<CarMovement>(out var value))
        {
            PlayerSpawn.currentTriggerPoint = this;
            PlayerSpawn.CheckAllTriggerPoint();
        }
    }
    public void ChecktriggerPoint()
    {
        if (PlayerSpawn.currentTriggerPoint == this)
        {
            Color green = new Color(0.3814302f, 0.8980392f, 0.3254902f);
            pointSpriteRenderer.color = green;
            foreach (SpawnPoint spawnPoint in spawnPointList)
            {
                spawnPoint.SetColor(green * 0.6f);
            }
        }
        else
        {
            Color red = new Color(0.8962264f, 0.3255162f, 0.3255162f);
            pointSpriteRenderer.color = red;
            foreach (SpawnPoint spawnPoint in spawnPointList)
            {
                spawnPoint.SetColor(red * 0.6f);
            }
        }
    }
    public Vector3 GetCharaterSpawnPointPosition(int teamTag)
    {
        return spawnPointList[teamTag % spawnPointList.Count].transform.position;
    }
}
