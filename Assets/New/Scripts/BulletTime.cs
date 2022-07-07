using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletTime : MonoBehaviour
{
    private float timer, multiScale;
    public int modDam, distance;
    private Rigidbody rb;
    [HideInInspector]
    public Vector3 angler, start, current;
    [HideInInspector]
    public string tagName;
    public int damage;
    public Shells[] shells;
    [HideInInspector]
    public bool cannon;
    public float speed, lifeSpan;
    [Range(0, 1)]
    public float capVolume;
    public AudioClip clip;
    public GameObject soundInstancer;

    // Start is called before the first frame update
    void Start()
    {
        if (soundInstancer != null)
        {
            soundInstancer.GetComponent<SpawneableSFX>().capVolume = capVolume;
            soundInstancer.GetComponent<SpawneableSFX>().clippie = clip;
        }
        start = transform.position;
        for (int i = 0; i < shells.Length; i++)
        {
            shells[i].tagName = tagName;
        }
        modDam = damage;
        rb = GetComponent<Rigidbody>();
        rb.velocity = new Vector3(angler.x * speed, angler.y * speed, angler.z * speed);
    }
    void Destroyed()
    {
        soundInstancer.transform.position = transform.position;
        Instantiate(soundInstancer);
        Destroy(gameObject);
    }
    // Update is called once per frame
    void Update()
    {
        if (cannon)
            CannonBullet();
        else
            NormalBullet();

    }

    void NormalBullet()
    {
        timer += Time.deltaTime;
        if (timer > lifeSpan)
        {
            Destroy(gameObject);
        }
    }

    void CannonBullet()
    {
        current = transform.position;
        distance = (int)Vector3.Distance(start, current);
        rb.velocity = new Vector3(angler.x * speed, angler.y * speed, angler.z * speed);
        /*switch (distance)
        {
            case 0 | 1:
                damage = (int)(modDam * 1.5f);
                multiScale = 0;
                    break;
            case 2 | 3:
                damage = modDam;
                multiScale = 0.5f;
                break;
            case 4 | 5 | 6 | 7:
                damage = modDam / 2;
                multiScale = 1;
                break;
        }*/
        if (distance <= 5)
        {
            damage = (int)(modDam * 1.5f);
            multiScale = 0;
        }
        else if (distance <= 10 && distance > 5)
        {
            damage = modDam;
            multiScale = 0.5f;

        }
        else if (distance <= 15 && distance > 10)
        {
            damage = modDam / 2;
            multiScale = 1;
        }
        foreach(Shells shellers in shells)
        {
            shellers.damage = damage;
        }
        transform.localScale = new Vector3(0.75f + multiScale, 0.75f + multiScale, 1);
        if (distance >= 16)
            Destroy(gameObject);
    }

    void OnTriggerEnter(Collider other)
    {
        if (!cannon)
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
}
