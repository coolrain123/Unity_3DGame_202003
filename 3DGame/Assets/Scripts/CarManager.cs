using UnityEngine;

public class CarManager : MonoBehaviour
{
    public Car Car1;


    
    private void Start()
    {
        Car1.Drive(999,dir: "後方");  //()內為引數
        Car1.Drive(123456.6f , "BANGGGGGG");  //()內為引數

        print("汽車1號是否開啟空調 :" + Car1.cool());
    }
}
