using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootPlayer : MonoBehaviour
{
    InputSystemActions inputStm;
    public GameObject bullet, targetPosition;
    public float maxTimer, bulletSpeed;
    public float timer, bulletAngle;
    public int damage;
    private Vector3 rec;
    private Pause pauseScript;
    private MP_System mpScript;
    // Start is called before the first frame update
    void Awake()
    {
        pauseScript = GameObject.FindGameObjectWithTag("Pause").GetComponent<Pause>();
        mpScript = GameObject.FindGameObjectWithTag("Player").GetComponent<MP_System>();
        inputStm = new InputSystemActions();
        inputStm.GamePlay.Atack.performed += _ => Shoot();
        inputStm.GamePlay.Recharge.performed += _ => Recharge();
    }
    void Start()
    {
        timer = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if(!pauseScript.paused)
        Delay();
    }
    void Delay()
    {
        timer += Time.deltaTime;
    }

    void Shoot()
    {
        if (timer >= maxTimer&&!pauseScript.paused&&mpScript.actualMP>=10)
        {
            bullet.transform.position = transform.position;
            rec = (transform.position - targetPosition.transform.position).normalized * -bulletSpeed;
            bullet.GetComponent<BulletTime>().angler = new Vector3(rec.x, rec.y, rec.z);
            bullet.GetComponent<BulletTime>().damage = damage;
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
            mpScript.BasicAttack();
            timer = 0;
            bullet.GetComponent<BulletTime>().damage = 0;
            bullet.GetComponent<BulletTime>().angler = new Vector3(0, 0, 0);
        }

    }
    void Recharge()
    {
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
