using UnityEngine;

public class PracticeMember : MonoBehaviour
{

    public SpriteRenderer KID;
    public Camera cam;


    //
    [Header("武器") ,Tooltip("這是主武")]
    public string weapon = "BB槍";
    [Header("分數"), Range(0, 100)]
    public int score = 100;



    private void Start()
    {
        //上課測試

        Cursor.visible = false;

        KID.flipX = true;

        print(Mathf.Floor(1.23456f));

        cam.transform.Rotate(0, 90, 0);


        
    }
}
