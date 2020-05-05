using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    
    public static float hp = 200;  //靜態static 會繼承到下一場景
    public static float delayFire = 0.5f;

    [Header("移動速度"), Range(1, 1000)]
    public float speed = 300;
    [Header("虛擬搖桿")]
    public Joystick joy;
    [Header("攻擊冷卻時間"), Range(0.1f, 10)]
    public float cd = 1;
   
    [Header("火球")]
    public GameObject fireBall;
    [Header("火球移動速度"), Range(1, 5000)]
    public float speedFireBall = 300;
    [Header("攻擊力"), Range(1, 5000)]
    public float attack = 35;
   
    public float hpMax ;

    public Image imgHp;

    private float timer;
    private Animator ani;
    private GameManager gm;

    private void Start()
    {
        // 取得元件<泛型>()
        ani = GetComponent<Animator>();
       // hp = hpMax;
        imgHp.fillAmount = hp / hpMax;

        gm = FindObjectOfType<GameManager>();
    }

    /// <summary>
    /// 移動
    /// </summary>
    public void Move()
    {
        float v = Input.GetAxis("Vertical");   //Vertical:WS上下
        float h = Input.GetAxis("Horizontal"); //Horizontal:AD左右
        transform.Translate(speed * Time.deltaTime * h, 0, speed * Time.deltaTime * v);

        float joyv = joy.Vertical;
        float joyh = joy.Horizontal;
        transform.Translate(speed * Time.deltaTime * joyh, 0, speed * Time.deltaTime * joyv);

        Vector3 pos = transform.position;
        pos.x = Mathf.Clamp(pos.x, 30, 70);
        pos.z = Mathf.Clamp(pos.z, 20, 30);
        transform.position = pos;

    }
    private void Update()
    {
        if (ani.GetBool("Dead")) return;
        Move();
        Attack();
        

    }

    /// <summary>
    /// 攻擊
    /// </summary>
    private void Attack()
    {
        timer += Time.deltaTime;                // 計時器 遞增

        if (timer >= cd)                        // 如果 計時器 >= 冷卻
        {
            timer = 0;                          // 計時器 歸零
            ani.SetTrigger("Attack");          // 動畫控制器.設定觸發器("參數名稱")

            StartCoroutine(DelayFireBall());    // 啟動協程
        }
    }
    /// <summary>
    /// 延遲生成火球
    /// </summary>
    private IEnumerator DelayFireBall()
    {
        yield return new WaitForSeconds(delayFire);             // 延遲生成火球

        Vector3 posFire = transform.position;                   // 火球座標 = 飛龍座標
        posFire.z += 4.2f;                                      // 微調 Z 軸
        posFire.y += 2.2f;

        GameObject temp = Instantiate(fireBall, posFire, Quaternion.identity);    // 生成(物件，座標，角度)

        temp.AddComponent<Ball>();                  // 暫存火球.添加元件<球>()
        temp.GetComponent<Ball>().damage = attack;  // 暫存火球.取得元件<球>().傷害值 = 攻擊力
        temp.GetComponent<Ball>().type = "玩家";
        // Quaternion.identity Unity 角度類型 - 零角度

        temp.GetComponent<Rigidbody>().AddForce(0, 0, speedFireBall);
    }

    private void eatPropCd()//吃加速水
    {
        cd -= 0.2f;
        cd = Mathf.Clamp(cd, 0.4f, 100);
    }
    private void eatPropHp()//吃補
    {
        StartCoroutine(HpRecover());
        //hp += 50;
        //hp = Mathf.Clamp(hp, 0, hpMax);
        //imgHp.fillAmount = hp / hpMax;
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "加速")
        {
            eatPropCd();
            Destroy(other.gameObject);
        }
        if (other.tag == "補血")
        {
            
            eatPropHp();
            Destroy(other.gameObject);
        }
    }
    private IEnumerator HpRecover()
    {
       float hpAdd =  hp + 70;

        while(hp < hpAdd)
        {
            hp++;
            hp = Mathf.Clamp(hp, 0, hpMax);
            imgHp.fillAmount = hp / hpMax;
            yield return null;
        }
        
    }

    /// <summary>
    /// 受傷
    /// </summary>
    /// <param name="damage">受到的傷害</param>
    public void Damage(float damage)
    {
        if (gm.passLv) return;
        hp -= damage;
        imgHp.fillAmount = hp / hpMax;
        if (hp <= 0) Dead();
        
    }
    public void Dead()
    {
        ani.SetBool("Dead", true);
        gm.Lose();
        
    }
}

