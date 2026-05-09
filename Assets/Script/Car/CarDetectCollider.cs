using System.Collections.Generic;
using UnityEngine;

public class CarDetectCollider : MonoBehaviour
{
    [SerializeField] CarMovement carMovement;
    [SerializeField] int teamTag;
    List<GameObject> colliderList = new List<GameObject>();
    void Update()
    {
        carMovement.isDetectTeammate = colliderList.Count > 0;
    }
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent<Charater>(out var value))
        {
            if (value.TeamTag == teamTag)
            {
                colliderList.Add(collision.gameObject);
            }
        }
    }
    void OnTriggerExit2D(Collider2D collision)
    {
        colliderList.Remove(collision.gameObject);
    }
}
