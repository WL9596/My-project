using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    [SerializeField] Charater TrackCharater;

    void Update()
    {
        transform.position = TrackCharater.transform.position + new Vector3(0,0,-10);
    }
}
