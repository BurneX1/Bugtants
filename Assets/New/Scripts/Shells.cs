using UnityEngine;

public class Shells : MonoBehaviour
{
    public string tagName;
    public int damage;
    [Range(0, 1)]
    public float capVolume;
    public AudioClip clip;
    public GameObject soundInstancer;
    // Start is called before the first frame update
    void Start()
    {
        soundInstancer.GetComponent<SpawneableSFX>().capVolume = capVolume;
        soundInstancer.GetComponent<SpawneableSFX>().clippie = clip;
    }
    void Destroyed()
    {
        soundInstancer.transform.position = transform.position;
        Instantiate(soundInstancer);
        Destroy(gameObject);
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
            Destroyed();
        }
        else if (other.CompareTag("FloorAndWall"))
        {
            damage = 0;
            Destroyed();
        }

    }
}
