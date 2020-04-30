using UnityEngine;



public class Monster : MonoBehaviour
{
    [Header("怪物資料")]
    public MonsterData Data;
    [Header("補血藥水")]
    public GameObject propHp;
    [Header("加速藥水")]
    public GameObject propCd;
    [Header("子彈")]
    public GameObject bullet;


    private Animator ani;
    private float hp;
    private float timer;

    private void Start()
    {
        hp = Data.hp;
        ani = GetComponent<Animator>();
    }
    private void Update()
    {
        Attack();
    }

    /// <summary>
    /// 受傷
    /// </summary>
    /// <param name="damage">受到的傷害</param>
    public void Damage(float damage)
    {
        print("受到的傷害" + damage);
        hp -= damage;
        if (hp <= 0)
        {
            Dead();
        }
    }
    public void Dead()
    {
        ani.SetBool("Dead", true);
        dropProp();
        Destroy(gameObject, 0.1f);
    }

    public void dropProp()
    {
        float rHp = Random.Range(0f, 1f);
        if (rHp < Data.propHpPer) Instantiate(propHp, transform.position + Vector3.right * Random.Range(-2f, 2f), Quaternion.identity);

        float rCd = Random.Range(0f, 1f);
        if (rCd < Data.propSpeedPer) Instantiate(propCd, transform.position + Vector3.right * Random.Range(-2f, 2f), Quaternion.identity);
    }
    public void Attack()
    {
        timer  += Time.deltaTime;
        if (timer >= Data.cd)
        {
            ani.SetTrigger("Attack");
            timer = 0;
            GameObject temp = Instantiate(bullet, transform.position +transform.forward + transform.up*2, Quaternion.identity);
            temp.AddComponent<Move>().moveSpeed = Data.bulletSpeed;            
            temp.GetComponent<Ball>().damage = Data.atk;
            temp.GetComponent<Ball>().type = "怪物";
        }
    }

}
