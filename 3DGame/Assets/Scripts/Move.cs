
using UnityEngine;

public class Move : MonoBehaviour
{
    [Header("移動速度"), Range(0, 100)]
    public float moveSpeed;

    public void MoveMethod()
    {
        transform.Translate(0, 0, -moveSpeed * Time.deltaTime, Space.World);
    }

    private void Update()
    {
        MoveMethod();
    }
}
