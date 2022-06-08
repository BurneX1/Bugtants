using UnityEngine;

public class BossAttacks : MonoBehaviour
{
    public int damage, areaChoose1, areaChoose2, areaChoose3, numberShoots;
    public float prepareSpeed, maxDelayTime, shootMaxTime, attackSpeed, bulletSpeed, stunDoneMaxTime, artillerySpeed, dropForce, stunRate, stunDrop;
    public GameObject slimeBall, eggBall, bullet, baronHuggers, randomSlime, randomEgg;
    [Tooltip("Tentaculos")]
    public GameObject tentaclesHor, tentaclesVer;
    public Detecter tentHor, tentVer, stunVer;
    public Transform mouth, locationer, gunLocation;
    private float timer = 0, choosedAngle;
    private int direction, locatedTentacle, shoots;
    [HideInInspector]
    public int step = 0;
    private bool damaged = false;
    private GameObject baronWheel, randomBullet;
    private GameObject[] a1, a2, a3;
    private bool[] b1, b2, b3;
    private void Awake()
    {
        a1 = new GameObject[8];
        a2 = new GameObject[8];
        a3 = new GameObject[8];
        b1 = new bool[8];
        b2 = new bool[8];
        b3 = new bool[8];
        for (int i = 0; i < a1.Length; i++)
        {
            a1[i] = GameObject.Find("Area1/Pos" + (i + 1));
            Debug.Log("Area1/Pos" + (i + 1));
            b1[i] = false;
        }
        for (int i = 0; i < a2.Length; i++)
        {
            a2[i] = GameObject.Find("Area2/Pos" + (i + 1));
            b2[i] = false;
        }
        for (int i = 0; i < a3.Length; i++)
        {
            a3[i] = GameObject.Find("Area3/Pos" + (i + 1));
            b3[i] = false;
        }
    }
    public void Attack_01(BossSense location)
    {
        switch (step)
        {
            case 0:
                timer += Time.deltaTime;
                if (timer >= maxDelayTime)
                {
                    timer = 0;
                    step++;
                }
                else if(timer >= maxDelayTime/2&&location.feel)
                {
                    timer = 0;
                    step++;
                }
                break;
            case 1:
                int localize;
                localize = Random.Range(0, 2);
                if (localize == 0)
                {
                    locatedTentacle = location.firstOption;
                    direction = 1;
                }
                else if (localize == 1)
                {
                    locatedTentacle = location.secondOption;
                    direction = -1;
                }
                choosedAngle = 225 - 90 * locatedTentacle;
                tentaclesHor.transform.localEulerAngles = new Vector3(0, choosedAngle, 0);
                step++;
                break;
            case 2:
                if (timer < 1)
                {
                    timer += Time.deltaTime * prepareSpeed;
                }
                else if (timer >= 1)
                {
                    timer = 1;
                }
                tentaclesHor.transform.localScale = new Vector3(1, 1, timer);
                if (timer == 1)
                {
                    timer = 0;
                    tentaclesHor.transform.localScale = new Vector3(1, 1, 1);
                    step++;
                }
                break;
            case 3:
                if (timer < 90 && timer > -90)
                {
                    timer += Time.deltaTime * direction * attackSpeed*10;
                    tentaclesHor.transform.localEulerAngles = new Vector3(0, choosedAngle + timer, 0);
                }
                else if (timer >= 90)
                {
                    timer = 90;
                    tentaclesHor.transform.localEulerAngles = new Vector3(0, choosedAngle + timer, 0);
                    step++;
                }
                else if (timer <= -90)
                {
                    timer = -90;
                    tentaclesHor.transform.localEulerAngles = new Vector3(0, choosedAngle + timer, 0);
                    step++;
                }
                if (tentHor.touch && !damaged)
                {
                    tentHor.registeredObject.GetComponent<Life>().ReduceLife(damage);
                    damaged = true;
                }
                break;
            case 4:
                if (timer != 1)
                {
                    timer = 1;
                    damaged = false;
                    step++;
                }
                break;
            case 5:
                if (timer > 0)
                {
                    timer -= Time.deltaTime * prepareSpeed;
                }
                else if (timer <= 0)
                {
                    timer = 0;
                }
                tentaclesHor.transform.localScale = new Vector3(1, 1, timer);
                if (timer == 0)
                {
                    timer = 0;
                    tentaclesHor.transform.localScale = new Vector3(1, 1, 0);
                    step = -1;
                }

                break;
        }
    } // Ataque tentáculo horizontalmente

    public void Attack_02(BossSense location) // Lanza baba
    {
        switch (step)
        {
            case 0:
                timer += Time.deltaTime;
                if (timer >= maxDelayTime)
                {
                    timer = 0;
                    step++;
                }
                break;
            case 1:
                Vector3 rec;
                randomSlime.transform.position = mouth.position;
                Vector3 up = mouth.position;
                up.y += 10;
                rec = (up - mouth.position).normalized;

                randomSlime.GetComponent<BulletTime>().speed = artillerySpeed;
                randomSlime.GetComponent<BulletTime>().angler = new Vector3(rec.x, rec.y, rec.z);
                randomSlime.GetComponent<BulletTime>().damage = damage;
                randomSlime.GetComponent<BulletTime>().tagName = "Player";

                randomSlime.transform.LookAt(location.objetive.transform, Vector3.forward);
                randomBullet=Instantiate(bullet);
                randomSlime.transform.position = new Vector3(0, 0, 0);
                randomSlime.transform.eulerAngles = new Vector3(0, 0, 0);

                step++;
                break;
            case 2:
                float distance=0;
                if (randomBullet != null)
                {
                    distance = Vector3.Distance(mouth.position, randomBullet.transform.position);
                }
                if (distance >= 10)
                {
                    Destroy(randomBullet);
                }
                if (randomBullet == null)
                {
                    step++;
                }
                break;
            case 3:
                for (int i = 0; i < areaChoose1; i++)
                {
                    int count = Random.Range(0, 8);
                    if (!b1[count])
                    {
                        b1[count] = true;
                    }
                    else
                    {
                        i--;
                    }
                }
                for (int i = 0; i < areaChoose2; i++)
                {
                    int count = Random.Range(0, 8);
                    if (!b2[count])
                    {
                        b2[count] = true;
                    }
                    else
                    {
                        i--;
                    }
                }
                for (int i = 0; i < areaChoose3; i++)
                {
                    int count = Random.Range(0, 8);
                    if (!b3[count])
                    {
                        b3[count] = true;
                    }
                    else
                    {
                        i--;
                    }
                }
                step++;
                break;
            case 4:
                slimeBall.GetComponent<DropBomb>().force = dropForce;
                slimeBall.GetComponent<DropBomb>().damage = damage;
                slimeBall.GetComponent<DropBomb>().stunRate = stunDrop;
                for (int i = 0; i < a1.Length; i++)
                {
                    if (b1[i])
                    {
                        Vector3 look = a1[i].transform.position;
                        look.y += 10;
                        slimeBall.transform.position = look;
                        Instantiate(slimeBall);
                        b1[i] = false;
                    }
                }
                for (int i = 0; i < a2.Length; i++)
                {
                    if (b2[i])
                    {
                        Vector3 look = a2[i].transform.position;
                        look.y += 10;
                        slimeBall.transform.position = look;
                        Instantiate(slimeBall);
                        b2[i] = false;
                    }
                }
                for (int i = 0; i < a3.Length; i++)
                {
                    if (b3[i])
                    {
                        Vector3 look = a3[i].transform.position;
                        look.y += 10;
                        slimeBall.transform.position = look;
                        Instantiate(slimeBall);
                        b3[i] = false;
                    }
                }
                step++;
                break;
            case 5:
                step = -1;
                break;
        }
    }


    public void Attack_03() // Invoca a 8 "Huggers"
    {
        switch (step)
        {
            case 0:
                timer += Time.deltaTime;
                if (timer >= maxDelayTime)
                {
                    timer = 0;
                    step++;
                }
                break;
            case 1:
                baronHuggers.transform.position = locationer.position;
                baronWheel = Instantiate(baronHuggers);
                step++;
                break;
            case 2:
                if (baronWheel == null)
                {
                    step = -1;
                }
                break;
        }

    }


    public void Attack_04(BossSense location) // Parecido a BeetleBomb pero a más balas
    {
        switch (step)
        {
            case 0:
                timer += Time.deltaTime;
                if (timer >= maxDelayTime)
                {
                    Vector3 rec;
                    bullet.transform.position = gunLocation.transform.position;
                    rec = (location.objetive.transform.position - gunLocation.transform.position).normalized;

                    bullet.GetComponent<BulletTime>().speed = bulletSpeed;
                    bullet.GetComponent<BulletTime>().angler = new Vector3(rec.x, rec.y, rec.z);
                    bullet.GetComponent<BulletTime>().damage = damage;

                    /*bulletLegion = Mathf.Atan2(rec.y, rec.z);
                    bulletLegion = bulletLegion * (180 / Mathf.PI);
                    bulletAngle = Mathf.Atan2(rec.z, rec.x);
                    bulletAngle = bulletAngle * (180 / Mathf.PI);*/

                    bullet.GetComponent<BulletTime>().tagName = "Player";
                    /*
                    if (bulletAngle < 0)
                        bulletAngle = 360 + bulletAngle;
                    if (bulletLegion < 0)
                        bulletLegion = 360 + bulletLegion;
                    */
                    bullet.transform.LookAt(location.objetive.transform, Vector3.forward);
                    Instantiate(bullet);
                    bullet.transform.position = new Vector3(0, 0, 0);
                    bullet.transform.eulerAngles = new Vector3(0, 0, 0);
                    shoots++;
                    timer = 0;
                }
                if (shoots >= numberShoots)
                {
                    step = -1;
                }
                break;

        }

    }


    public void Attack_05(BossSense location) // Como la 2 pero a huevos
    {
        switch (step)
        {
            case 0:
                timer += Time.deltaTime;
                if (timer >= maxDelayTime)
                {
                    timer = 0;
                    step++;
                }
                break;
            case 1:
                Vector3 rec;
                randomEgg.transform.position = mouth.position;
                Vector3 up = mouth.position;
                up.y += 10;
                rec = (up - mouth.position).normalized;

                randomEgg.GetComponent<BulletTime>().speed = artillerySpeed;
                randomEgg.GetComponent<BulletTime>().angler = new Vector3(rec.x, rec.y, rec.z);
                randomEgg.GetComponent<BulletTime>().damage = damage;
                randomEgg.GetComponent<BulletTime>().tagName = "Player";

                randomEgg.transform.LookAt(location.objetive.transform, Vector3.forward);
                randomBullet = Instantiate(bullet);
                randomEgg.transform.position = new Vector3(0, 0, 0);
                randomEgg.transform.eulerAngles = new Vector3(0, 0, 0);

                step++;
                break;
            case 2:
                float distance = 0;
                if (randomBullet != null)
                {
                    distance = Vector3.Distance(mouth.position, randomBullet.transform.position);
                }
                if (distance >= 10)
                {
                    Destroy(randomBullet);
                }
                if (randomBullet == null)
                {
                    step++;
                }
                break;
            case 3:
                for (int i = 0; i < areaChoose1; i++)
                {
                    int count = Random.Range(0, 8);
                    if (!b1[count])
                    {
                        b1[count] = true;
                    }
                    else
                    {
                        i--;
                    }
                }
                for (int i = 0; i < areaChoose2; i++)
                {
                    int count = Random.Range(0, 8);
                    if (!b2[count])
                    {
                        b2[count] = true;
                    }
                    else
                    {
                        i--;
                    }
                }
                for (int i = 0; i < areaChoose3; i++)
                {
                    int count = Random.Range(0, 8);
                    if (!b3[count])
                    {
                        b3[count] = true;
                    }
                    else
                    {
                        i--;
                    }
                }
                step++;
                break;
            case 4:
                eggBall.GetComponent<DropBomb>().force = dropForce;
                eggBall.GetComponent<DropBomb>().damage = damage;
                eggBall.GetComponent<DropBomb>().stunRate = stunDrop;
                for (int i = 0; i < a1.Length; i++)
                {
                    if (b1[i])
                    {
                        Vector3 look = a1[i].transform.position;
                        look.y += 10;
                        eggBall.transform.position = look;
                        Instantiate(eggBall);
                        b1[i] = false;
                    }
                }
                for (int i = 0; i < a2.Length; i++)
                {
                    if (b2[i])
                    {
                        Vector3 look = a2[i].transform.position;
                        look.y += 10;
                        eggBall.transform.position = look;
                        Instantiate(eggBall);
                        b2[i] = false;
                    }
                }
                for (int i = 0; i < a3.Length; i++)
                {
                    if (b3[i])
                    {
                        Vector3 look = a3[i].transform.position;
                        look.y += 10;
                        eggBall.transform.position = look;
                        Instantiate(eggBall);
                        b3[i] = false;
                    }
                }
                step++;
                break;
            case 5:
                step = -1;
                break;
        }

    }


    public void Attack_06(BossSense location) //Como la 1 pero de arriba para abajo
    {
        switch (step)
        {
            case 0:
                tentaclesVer.transform.localScale = new Vector3(1, 1, 0);
                tentaclesVer.transform.localEulerAngles = new Vector3(-100, 0, 0);
                step++;
                break;
            case 1:
                if (timer < 1)
                {
                    timer += Time.deltaTime * prepareSpeed;
                }
                else if (timer >= 1)
                {
                    timer = 1;
                }
                tentaclesVer.transform.localScale = new Vector3(1, 1, timer);
                if (timer == 1)
                {
                    timer = 0;
                    tentaclesVer.transform.localScale = new Vector3(1, 1, 1);
                    step++;
                }
                break;
            case 2:
                float angle;
                angle = location.transform.localEulerAngles.y;
                tentaclesVer.transform.localEulerAngles = new Vector3(-100, angle, 0);
                timer += Time.deltaTime;
                if (timer >= maxDelayTime)
                {
                    choosedAngle = angle;
                    timer = -100;
                    step++;
                }

                break;
            case 3:
                if (timer < 0)
                {
                    timer += Time.deltaTime * attackSpeed * 10;
                    tentaclesVer.transform.localEulerAngles = new Vector3(timer, choosedAngle, 0);
                }
                else if (timer >= 0)
                {
                    timer = 0;
                    tentaclesVer.transform.localEulerAngles = new Vector3(timer, choosedAngle, 0);
                    //Instanciar el área stuneo, que dependa la distancia y el tiempo que pasa y luego desaparece
                    step++;
                }
                if (tentVer.touch && !damaged)
                {
                    tentVer.registeredObject.GetComponent<Life>().ReduceLife(damage);
                    damaged = true;
                }

                break;
            case 4:
                if (stunVer.touch)
                {
                    stunVer.registeredObject.GetComponent<PlayerController>().Stunning(stunRate);
                }
                step++;
                break;
            case 5:
                timer += Time.deltaTime;
                if (timer >= stunDoneMaxTime)
                {
                    timer = 1;
                    damaged = false;
                    step++;
                }
                break;
            case 6:
                if (timer > 0)
                {
                    timer -= Time.deltaTime * prepareSpeed;
                }
                else if (timer <= 0)
                {
                    timer = 0;
                }
                tentaclesVer.transform.localScale = new Vector3(1, 1, timer);
                if (timer == 0)
                {
                    timer = 0;
                    tentaclesVer.transform.localScale = new Vector3(1, 1, 0);
                    step = -1;
                }
                break;
        }
    }

}
