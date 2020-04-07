using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    public Enemy enemy1, enemy2;
    private void Start()
    {
        print(enemy1.HP);
        enemy2.HP = 600;

        enemy1.attack = 999;



        print("怪物2號的等級為" + enemy2.lv);
        print("怪物2號的MP為" + enemy2.mp);
        print("怪物2號的防禦力為為" + enemy2.def);

        enemy2.damage = 99;
        enemy1.damage = 10;
        print("怪物2號最後受到的傷害" + enemy2.damage);
        print("怪物1號最後受到的傷害" + enemy1.damage);

    }
}
