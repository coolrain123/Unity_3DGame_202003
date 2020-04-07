using UnityEngine;

public class Enemy : MonoBehaviour
{
    /// <summary>
    /// 這是怪物的血量
    /// </summary>
    [Header("血量")]
    public int HP = 50;


    //屬性Property 
    //可以設定權限:唯讀、允許所有權限
    //get 取得
    //set 設定

    public int attack { get; set; }
    //public float def { get;  }//沒有set 便不能在程式內設定其值

    public float def
    {
        get
        {
            return 77.5f;  //以此方式設定屬性的基礎職
        }
    }


    public int lv = 5;

    //下方程式有誤  無法在欄位指定後面使用欄位
    //public int mp = lv * 8;

    public int mp
    {
        get
        {
            return lv * 8;  //屬性中可以使用欄位
        }
    }

    //C# 物件導向程式設計三大核心之一 : 封裝
    private float _damage;

    public float damage
    {
        set
        {
            _damage = Mathf.Clamp(value - def, 1, 99999);  // Mathf.Clamp(值,最小值,最大值)   箝 :值不能超出最大最小值
        }
        get
        {
            return _damage;
        }
    }
}
