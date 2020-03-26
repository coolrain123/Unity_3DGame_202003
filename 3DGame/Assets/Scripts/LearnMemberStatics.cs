using UnityEngine;

public class LearnMemberStatics : MonoBehaviour
{
    float a = 0.5f;
    int b = 3;
    bool c = true;
    bool d = false;
    string e = "字串";

    public Camera cam;

    private void Start()
    {
        print(Random.value);
        print(Random.Range(0, 100));

        Time.timeScale = 0.5f;

        print(Mathf.Abs(-999));
        print(Mathf.PI);

        print(cam.depth);
        print("攝影機數量:" + Camera.allCamerasCount);
        
    }
}
