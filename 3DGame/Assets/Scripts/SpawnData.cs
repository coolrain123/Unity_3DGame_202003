using UnityEngine;

[CreateAssetMenu(fileName = "關卡生怪資料", menuName = "coolrain/關卡生怪資料")]
public class SpawnData : ScriptableObject
{
    public SpawnTime[] spawn;
}

[System.Serializable]  //序列化:顯示在Unity屬性面板(class專用)
public class SpawnTime
{
    public string name;
    public float time;
    public SpawnMonster[] Monsters;

}
[System.Serializable]
public class SpawnMonster
{
    public GameObject Monster;
    public float x;
}