using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMidDistance : MonoBehaviour
{
    public GameObject bullet, bulletPosition;
    public float maxTimer, bulletSpeed;
    public int damage;
    public EnemyGroundMove movement;
    private float timer, bulletAngle;
    private Vector2 rec;
    // Start is called before the first frame update
    void Start()
    {
        timer = 0;
    }

    // Update is called once per frame
    void Update()
    {
        Shoot();
    }
    void Shoot()
    {
        timer += Time.deltaTime;
        if (timer >= maxTimer && (movement.statNumber == 2|| movement.statNumber == 3))
        {
            Vector2 playerPointer = new Vector2(movement.radium.objetive.transform.position.x, movement.radium.objetive.transform.position.z);
            Vector2 pointer = new Vector2(transform.position.x, transform.position.z);
            bullet.transform.position = bulletPosition.transform.position;
            rec = (playerPointer - pointer).normalized * bulletSpeed;
            bullet.GetComponent<BulletTime>().angler = new Vector3(rec.x, 0, rec.y);
            bullet.GetComponent<BulletTime>().damage = damage;
            bulletAngle = Mathf.Atan2(rec.y, -rec.x);
            bulletAngle = bulletAngle * (180 / Mathf.PI);
            bullet.GetComponent<BulletTime>().tagName = "Player";
            if (bulletAngle < 0)
            {

                bulletAngle = 360 + bulletAngle;

            }
            bullet.transform.eulerAngles = new Vector3(0, bulletAngle-90, 0);
            Instantiate(bullet);
            bullet.transform.position = new Vector3(0, 0, 0);
            bullet.transform.eulerAngles = new Vector3(0, 0, 0);
            timer = 0;
        }
    }
}
