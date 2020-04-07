using UnityEngine;

public class Car : MonoBehaviour
{
    //方法語法:修飾詞 傳回類型 方法名稱(參數) {陳述式}
    //void 無傳回: 使用此方法時不會有任何資料傳回
    //參數 (類型 名稱)

    public void Drive(float speed , string sound = "咻咻咻" , string dir = "前方")
    {
        print("開車咯~時速 : "+ speed);
        print("開車音效" + sound);
        print("開車方向" + dir);

    }
    public bool cool()
    {
        print("開空調啦!!!");
        return true;
    }
}
