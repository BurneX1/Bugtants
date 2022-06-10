using UnityEngine;

public class Shells : MonoBehaviour
{
    public string tagName;
    public int damage;
    [HideInInspector]
    // Start is called before the first frame update
    void Start()
    {

    }
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(tagName))
        {
            if (other.GetComponent<Life>() != null)
            {
                other.GetComponent<Life>().ReduceLife(damage);
            }
            else if (other.GetComponent<Eye>() != null)
            {
                other.GetComponent<Eye>().ReduceHealth(damage);
            }
            else if (other.GetComponent<EnemyLife>() != null)
            {
                other.GetComponent<EnemyLife>().ChangeLife(-damage);
            }
            damage = 0;
            Destroy(gameObject);
        }
        else if (other.CompareTag("FloorAndWall"))
        {
            damage = 0;
            Destroy(gameObject);
        }

    }
}
