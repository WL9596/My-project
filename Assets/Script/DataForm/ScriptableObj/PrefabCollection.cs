using UnityEngine;
using System;

[Serializable]
[CreateAssetMenu(fileName = "prefabCollection", menuName = "DataForm/Create Prefab Collection Assest", order = 0)]
public class PrefabCollection : ScriptableObject
{
    static PrefabCollection instance;

    public static PrefabCollection Instance
    {
        get
        {
            if (instance == null)
            {
                instance = Resources.Load<PrefabCollection>("prefabCollection");
            }
            return instance;
        }
    }

    [Header("Charater")]
    public GameObject rrrose;

    [Header("Bullet")]
    public GameObject rrroseRifleBullet;
}
