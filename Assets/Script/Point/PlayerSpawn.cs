using System.Collections.Generic;
using UnityEngine;

public static class PlayerSpawn
{
    public static CarPoint currentTriggerPoint;
    public static List<CarPoint> carPointList = new List<CarPoint>();
    public static void CheckAllTriggerPoint()
    {
        foreach(CarPoint point in carPointList)
        {
            point.ChecktriggerPoint();
        }
    }
}
