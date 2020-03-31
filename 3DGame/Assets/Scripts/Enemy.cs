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

}
