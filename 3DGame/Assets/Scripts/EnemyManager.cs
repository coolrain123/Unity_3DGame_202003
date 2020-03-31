using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    public Enemy enemy1, enemy2;
    private void Start()
    {
        print(enemy1.HP);
        enemy2.HP = 600;

        enemy1.attack = 999;

    }
}
