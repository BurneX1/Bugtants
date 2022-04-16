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

    // Start is called before the first frame update
    void Awake()
    {
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
        Delay();
    }
    void Delay()
    {
        timer += Time.deltaTime;
    }

    void Shoot()
    {
        if (timer >= maxTimer)
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
