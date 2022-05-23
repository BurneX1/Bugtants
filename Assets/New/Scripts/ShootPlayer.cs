using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootPlayer : MonoBehaviour
{
    public GameObject bull, shotbull, targetPosition;
    private GameObject bullet;
    public float maxTimer, bulletSpeed;
    private float timer, bulletAngle;
    public bool cannon;
    public int damagePistol, damageShotgun;
    private Vector3 rec;
    private Pause pauseScript;

    [HideInInspector]
    public bool waiting;
    // Start is called before the first frame update
    void Awake()
    {
        pauseScript = GameObject.FindGameObjectWithTag("Pause").GetComponent<Pause>();
        waiting = false;
    }
    void Start()
    {
        timer = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (!pauseScript.paused && !waiting && timer <= maxTimer)
            Delay();
    }
    void Delay()
    {
        timer += Time.deltaTime;
    }
    public void ResetTime()
    {

    }
    public void Shooting(WeaponStats weaponStat, MP_System mpScript)
    {
        if (timer >= maxTimer && !pauseScript.paused && mpScript.actualMP >= weaponStat.mpCost && !waiting)
        {

            bullet = weaponStat.bulletType;
            bullet.transform.position = transform.position;
            rec = (targetPosition.transform.position - transform.position).normalized;
            
            bullet.GetComponent<BulletTime>().speed = weaponStat.bulletSpeed;
            bullet.GetComponent<BulletTime>().angler = new Vector3(rec.x, rec.y, rec.z);
            
            bullet.GetComponent<BulletTime>().damage = weaponStat.damage;
            bulletAngle = Mathf.Atan2(rec.y, -rec.x);
            bulletAngle = bulletAngle * (180 / Mathf.PI);

            bullet.GetComponent<BulletTime>().tagName = "Enemy";

            if (bulletAngle < 0)
                bulletAngle = 360 + bulletAngle;
            bullet.transform.eulerAngles = transform.eulerAngles;
            Instantiate(bullet);
            bullet.transform.position = new Vector3(0, 0, 0);
            bullet.transform.eulerAngles = new Vector3(0, 0, 0);

            mpScript.ModifyMp(-weaponStat.mpCost);

            timer = 0;
            bullet.GetComponent<BulletTime>().damage = 0;
            bullet.GetComponent<BulletTime>().angler = new Vector3(0, 0, 0);
        
        }
    }
    public void Recharge(MP_System mpScript)
    {
        if(!waiting)
        mpScript.FullRecharge();
    }

}
