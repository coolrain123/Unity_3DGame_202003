using UnityEngine;


[CreateAssetMenu(fileName = "怪物資料",menuName = "coolrain/怪物資料")]
public class MonsterData : ScriptableObject
{
    [Header("攻擊力"), Range(0, 100000)]
    public float atk;
    [Header("血量"), Range(0, 100000)]
    public float hp;
    [Header("移動速度"), Range(0, 100000)]
    public float speed;
    [Header("補血藥水掉落機率"),Range(0,1)]
    public float propHpPer;
    [Header("加速藥水掉落機率"), Range(0, 1)]
    public float propSpeedPer;
    [Header("攻擊冷卻"), Range(0, 5)]
    public float cd;
    [Header("子彈速度"), Range(1, 50)]
    public float bulletSpeed;
}
