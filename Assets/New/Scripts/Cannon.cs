using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cannon : MonoBehaviour
{
    private Rigidbody rigid;
    [HideInInspector]
    public float height, distance, angle;
    private GameObject target;
    private Vector3 rec, xVert, yPol;
    // Start is called before the first frame update
    void Start()
    {
        rigid = GetComponent<Rigidbody>();
        target = GameObject.FindGameObjectWithTag("Player");
        xVert = target.transform.position;
        xVert.y = transform.position.y;
        yPol = target.transform.position;
        yPol.x = transform.position.x;
        yPol.z = transform.position.z;
        rec = (target.transform.position - transform.position).normalized;
        distance = Vector3.Distance(transform.position, xVert);
        height = Vector3.Distance(transform.position, yPol);
        //rb2d.AddForce(Quaternion.AngleAxis(30f, Vector3.forward) * transform.up * 100.0f);      
        angle = Mathf.Atan2(rec.x, rec.z);
        angle = angle * (180 / Mathf.PI);
        if (angle < 0)
        {
            angle = 360 + angle;
        }
        transform.eulerAngles = new Vector3(0, angle, 0);
        rigid.AddForce(transform.forward * distance * 10);
        rigid.AddForce(transform.up * (height + 15) * 100);

    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.CompareTag("FloorAndWall"))
        {
            Destroy(gameObject);
        }
    }
}
