using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropBomb : MonoBehaviour
{
    private Rigidbody rigid;
    [HideInInspector]
    public float force;
    [HideInInspector]
    public int damage;
    public GameObject contain;
    // Start is called before the first frame update
    void Start()
    {
        rigid = GetComponent<Rigidbody>();
        rigid.AddForce(transform.up * -10 * force);
    }



    // Update is called once per frame
    void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.CompareTag("FloorAndWall"))
        {
            contain.transform.position = transform.position;
            Vector3 look = contain.transform.position;
            look.y += 1;
            contain.transform.position = look;
            Instantiate(contain);
            Destroy(gameObject);

        }
        if (collision.CompareTag("Player"))
        {
            if (collision.GetComponent<Life>() != null)
            {
                collision.GetComponent<Life>().ReduceLife(damage);
            }
            contain.transform.position = transform.position;
            Vector3 look = contain.transform.position;
            look.y += 1;
            contain.transform.position = look;
            Instantiate(contain);
            Destroy(gameObject);
        }
    }
}
