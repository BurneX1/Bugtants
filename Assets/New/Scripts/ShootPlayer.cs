using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootPlayer : MonoBehaviour
{
    InputSystemActions inputStm;
    public GameObject bull, shotbull, targetPosition;
    private GameObject bullet;
    public float maxTimer, bulletSpeed;
    public float timer, bulletAngle, mod;
    public bool cannon;
    public int damagePistol, damageShotgun;
    private Vector3 rec;
    private Pause pauseScript;
    private MP_System mpScript;

    [HideInInspector]
    public bool waiting;
    // Start is called before the first frame update
    void Awake()
    {
        pauseScript = GameObject.FindGameObjectWithTag("Pause").GetComponent<Pause>();
        mpScript = GameObject.FindGameObjectWithTag("Player").GetComponent<MP_System>();
        inputStm = new InputSystemActions();
        inputStm.GamePlay.Atack.performed += _ => Shoot();
        inputStm.GamePlay.Recharge.performed += _ => Recharge();
        waiting = false;
    }
    void Start()
    {
        timer = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if(!pauseScript.paused && !waiting)
        Delay();
    }
    void Delay()
    {
        timer += Time.deltaTime;
    }
    void Shoot()
    {
        if (timer >= maxTimer&&!pauseScript.paused&&mpScript.actualMP>=10 && !waiting)
        {
            if (cannon)
                bullet = shotbull;
            else
                bullet = bull;
            bullet.transform.position = transform.position;
            rec = (targetPosition.transform.position - transform.position).normalized;
            bullet.GetComponent<BulletTime>().speed = bulletSpeed;
            bullet.GetComponent<BulletTime>().angler = new Vector3(rec.x, rec.y, rec.z);
            if (cannon)
                bullet.GetComponent<BulletTime>().damage = damageShotgun;
            else
                bullet.GetComponent<BulletTime>().damage = damagePistol;
            bullet.GetComponent<BulletTime>().cannon = cannon;
            bulletAngle = Mathf.Atan2(rec.y, -rec.x);
            bulletAngle = bulletAngle * (180 / Mathf.PI);
            bullet.GetComponent<BulletTime>().tagName = "Enemy";
            if (bulletAngle < 0)
            {

                bulletAngle = 360 + bulletAngle;

            }
            bullet.transform.eulerAngles = transform.eulerAngles;
            Instantiate(bullet);
            bullet.transform.position = new Vector3(0, 0, 0);
            bullet.transform.eulerAngles = new Vector3(0, 0, 0);
            if (cannon)
                mpScript.Shotgun();
            else
                mpScript.Pistol();
            timer = 0;
            bullet.GetComponent<BulletTime>().damage = 0;
            bullet.GetComponent<BulletTime>().angler = new Vector3(0, 0, 0);
        }

    }
    void Recharge()
    {
        if(!waiting)
        mpScript.FullRecharge();
    }
    private void OnEnable()
    {
        inputStm.Enable();
    }

    private void OnDisable()
    {
        inputStm.Disable();
    }

}
