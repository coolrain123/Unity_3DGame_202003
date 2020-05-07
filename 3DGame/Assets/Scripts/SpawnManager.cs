using UnityEngine;
using System.Collections;

public class SpawnManager : MonoBehaviour
{
    [Header("關卡生怪資料")]
    public SpawnData data;

    private GameManager gm;
    private void Start()
    {
        gm = FindObjectOfType<GameManager>();
        StartCoroutine(SpawnMonster());
    }

    private IEnumerator SpawnMonster()
    {
        for (int i = 0; i < data.spawn.Length; i++)
        {
            yield return new WaitForSeconds(data.spawn[i].time);

            for (int j = 0; j < data.spawn[i].Monsters.Length; j++)
            {
                Vector3 pos = new Vector3(data.spawn[i].Monsters[j].x, 17, 55);

                Quaternion qua = Quaternion.Euler(0, 180, 0);

                Instantiate(data.spawn[i].Monsters[j].Monster, pos, qua);

            }
        }
        yield return new WaitForSeconds(10);
        gm.Win();
    }
}
