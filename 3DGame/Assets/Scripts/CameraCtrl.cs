using UnityEngine;

public class CameraCtrl : MonoBehaviour
{
    public Transform Dragon;

    [Header("追蹤速度"), Range(1, 100)]
    public float speed = 1;

    private void LateUpdate()
    {
        Track();
    }

    public void Track()
    {
        Vector3 drapos = Dragon.position;
        drapos.y = 50;
        drapos.z -= 10;

        transform.position = Vector3.Lerp(transform.position, drapos, 0.4f * Time.deltaTime * speed);
    }
}
