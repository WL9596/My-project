using UnityEngine;

public class MatchProcessManager : MonoBehaviour
{
    static MatchProcessManager instance;
    public static MatchProcessManager Instance => instance;
    public void Awake()
    {
        instance = this;
    }
}
