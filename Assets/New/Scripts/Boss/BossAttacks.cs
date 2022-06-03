using UnityEngine;

public class BossAttacks : MonoBehaviour
{
    public int damage;
    public float prepareSpeed, maxDelayTime, attackSpeed, bulletSpeed, stunDoneMaxTime;
    public GameObject slimeBall, eggBall, bullet, baronHuggers;
    [Tooltip("Tentaculos")]
    public GameObject tentaclesHor, tentaclesVer;
    public Transform mouth, locationer, gunLocation;
    private float timer = 0, choosedAngle;
    private int direction, locatedTentacle;
    [HideInInspector]
    public int step = 0;
    private GameObject baronWheel;
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
                break;
            case 4:
                if (timer != 1)
                {
                    timer = 1;
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

                break;
            case 2:

                break;
            case 3:

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


    public void Attack_04(BossSense location) // Parecido a BeetleBomb
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
                
                step = -1;
                break;

        }

    }


    public void Attack_05() // Como la 2 pero a huevos
    {
        switch (step)
        {
            case 0:
                step++;
                break;

            case 1:

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
                angle = location.transform.eulerAngles.y;
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
                break;
            case 4:
                timer += Time.deltaTime;
                if (timer >= stunDoneMaxTime)
                {
                    timer = 1;
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
