using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletTime : MonoBehaviour
{
    private float timer, baseSpeed;
    private int modDam;
    private Rigidbody rb;
    [HideInInspector]
    public Vector3 angler;
    [HideInInspector]
    public string tagName;
    public int damage;
    [HideInInspector]
    public bool cannon;
    public float modifier, speed;
    // Start is called before the first frame update
    void Start()
    {
        baseSpeed = speed;
        modDam = damage;
        rb = GetComponent<Rigidbody>();
        rb.velocity = new Vector3(angler.x * speed, angler.y * speed, angler.z * speed);
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
        if (timer > 3)
        {
            Destroy(gameObject);
        }
    }

    void CannonBullet()
    {
        rb.velocity = new Vector3(angler.x * speed, angler.y * speed, angler.z * speed);
        speed -= Time.deltaTime * modifier;
        //(250 / 10 = 25)
        //(10 * 25) / (20 / 2)
        damage = ((int)speed * modDam) / ((int)baseSpeed / 2);
        if (speed <= 0)
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
            else if(other.GetComponent<EnemyLife>() != null)
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
