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
}
