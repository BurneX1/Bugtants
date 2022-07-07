using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMidDistance : MonoBehaviour
{
    public GameObject bullet, bulletPosition;
    public float maxTimer, bulletSpeed;
    public int damage;
    public EnemyGroundMove movement;
    private float timer, bulletAngle,bulletLegion;
    private Vector3 rec;
    public WaysToSound waysShoot;
    // Start is called before the first frame update
    void Start()
    {
        waysShoot.sounds = gameObject.GetComponent<SoundActive>();
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
        if (timer >= maxTimer && (movement.statNumber == 2 || movement.statNumber == 3 || movement.statNumber == 5))
        {
            Vector3 playerStat = movement.radium.objetive.transform.position;
            playerStat.y += 1f;
            bullet.transform.position = bulletPosition.transform.position;
            rec = (playerStat - bulletPosition.transform.position).normalized;

            bullet.GetComponent<BulletTime>().speed = bulletSpeed;
            bullet.GetComponent<BulletTime>().angler = new Vector3(rec.x, rec.y, rec.z);
            bullet.GetComponent<BulletTime>().damage = damage;
            
            bulletLegion = Mathf.Atan2(rec.y, rec.z);
            bulletLegion = bulletLegion * (180 / Mathf.PI);
            bulletAngle = Mathf.Atan2(rec.z, rec.x);
            bulletAngle = bulletAngle * (180 / Mathf.PI);

            bullet.GetComponent<BulletTime>().tagName = "Player";
            
            if (bulletAngle < 0)
                bulletAngle = 360 + bulletAngle;
            if (bulletLegion < 0)
                bulletLegion = 360 + bulletLegion;

            bullet.transform.LookAt(movement.radium.objetive.transform, Vector3.forward);
            waysShoot.StopThenActive();
            Instantiate(bullet);
            bullet.transform.position = new Vector3(0, 0, 0);
            bullet.transform.eulerAngles = new Vector3(0, 0, 0);
            timer = 0;
        }
    }
}
