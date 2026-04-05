using UnityEngine;

public class AttackManager : MonoBehaviour
{
    public static AttackManager Instance=>instance;
    static AttackManager instance;

    void Awake()
    {
        instance = this;
    }

    /// <summary>
    /// 本函數將會是別attackInfo的具體類型進行對應的處裡，並在未來會和網路接口做連接
    /// </summary>
    /// <param name="attackInfo"></param>
    public void DamageRegister(AttackInfo attackInfo)
    {
        
    }
}
