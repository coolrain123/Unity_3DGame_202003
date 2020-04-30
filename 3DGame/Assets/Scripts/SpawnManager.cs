using UnityEngine;
using System.Collections;

public class SpawnManager : MonoBehaviour
{
    [Header("關卡生怪資料")]
    public SpawnData data;

    private void Start()
    {
        
    }

    private IEnumerator SpawnMonster()
    {
        for (int i = 0; i < data.spawn.Length; i++)
        {
            yield return new WaitForSeconds(data.spawn[i].time);
            //Instantiate(data.spawn[i].Monsters, transform.position, Quaternion.identity);
        }
    }
}
