using UnityEngine;

public class CharaterRespawnController : MonoBehaviour
{
    [SerializeField] Charater charater;
    void Update()
    {
        if(charater.Property.Health<=0)
        {
            charater.Respawn(PlayerSpawn.currentTriggerPoint.GetCharaterSpawnPointPosition(charater.TeamTag));
        }
    }
}
