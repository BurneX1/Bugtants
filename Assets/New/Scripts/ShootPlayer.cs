using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootPlayer : MonoBehaviour
{
    InputSystemActions inputStm;
    public GameObject bullet, targetPosition;
    public float maxTimer, bulletSpeed;
    private float timer, bulletAngle;
    private Vector3 rec;
    private Pause pauseScript;
    // Start is called before the first frame update
    void Awake()
    {
        pauseScript = GameObject.FindGameObjectWithTag("Pause").GetComponent<Pause>();
        inputStm = new InputSystemActions();
        inputStm.GamePlay.Atack.performed += _ => Shoot();
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
        if (timer >= maxTimer&&!pauseScript.paused)
        {
            bullet.transform.position = transform.position;
            rec = (transform.position - targetPosition.transform.position).normalized * -bulletSpeed;
            bullet.GetComponent<BulletTime>().angler = new Vector3(rec.x, rec.y, rec.z);
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
            timer = 0;
        }

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
