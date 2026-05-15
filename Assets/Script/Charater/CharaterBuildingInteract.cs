using System.Collections.Generic;
using UnityEngine;

public class CharaterBuildingInteract : MonoBehaviour
{
    List<Building> buildingList = new List<Building>();
    public void TryInteract()
    {
        Building targetBuilding = null;
        foreach (Building building in buildingList)
        {
            if (building.IsInteractable
            && (targetBuilding == null
            || Vector3.Magnitude(targetBuilding.transform.position - transform.position) > Vector3.Magnitude(building.transform.position - transform.position)))
            {
                
                targetBuilding = building;
            }
        }
        Debug.Log($"try interact {targetBuilding} | list count:{buildingList.Count}");
        targetBuilding?.Interact();
    }
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent<Building>(out var value))
        {
            buildingList.Add(value);
        }
    }
    void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.TryGetComponent<Building>(out var value))
        {
            buildingList.Remove(value);
        }
    }
}
