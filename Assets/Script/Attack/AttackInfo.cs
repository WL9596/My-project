using System.Collections.Generic;
using UnityEngine;

public class AttackInfo
{
    public DamageInfo damageInfo;
}
public class RaycastAttackInfo : AttackInfo
{
    public Vector2 originalPosition;
    /// <summary>
    /// targetAmount:
    /// 射線上最接近原點的幾個敵人會被命中，-1將命中線上所有敵人
    /// </summary>
    public int targetAmount;
    public Vector2 direction;
    public float length;
}
public class BoxcastAttackInfo : AttackInfo
{

}
public class CirclecastAttackInfo : AttackInfo
{
}

/// <summary>
/// 為了防止作弊，在註冊攻擊訊息時，應該要傳輸只帶有攻擊者(哪個武器or武器的子物件早成的攻擊)資訊的攻擊就好
/// 由伺服器再根據該武器與該角色當前的狀態產生具體的AttackInfo
/// </summary>
// public class WeaponAttackInfo : AttackInfo
// {
//     // Weaponinformation...
//     // Charater...
// }