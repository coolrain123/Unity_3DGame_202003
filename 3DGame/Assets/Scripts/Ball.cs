using UnityEngine;

public class Ball : MonoBehaviour
{


    public string type;
    public float damage;
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "怪物"  && type == "玩家")
        {
            other.GetComponent<Monster>().Damage(damage);
            Destroy(gameObject);
        }

        if (other.name == "飛龍" && type == "怪物")
        {
            other.GetComponent<Player>().Damage(damage);
            Destroy(gameObject);
        }

    }
}
