using UnityEngine;



public class Monster : MonoBehaviour
{
    [Header("怪物資料")]
    public MonsterData Data;
    
    private Animator ani;
    private float hp;

    private void Start()
    {
        hp = Data.hp;
       ani =  GetComponent<Animator>();
    }

    /// <summary>
    /// 受傷
    /// </summary>
    /// <param name="damage">受到的傷害</param>
    public void Damage(float damage)
    {
        hp -= damage;
        if (hp <= 0)
        {
            Dead();
        }
    }
    public void Dead()
    {
        ani.SetBool("Dead",true);
    }

}
