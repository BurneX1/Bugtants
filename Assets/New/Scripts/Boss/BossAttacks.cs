using UnityEngine;

public class BossAttacks : MonoBehaviour
{
    public int damage;
    public float prepareSpeed, maxDelayTime, attackSpeed;
    public GameObject slimeBall, eggBall, baronHuggers;
    public GameObject tentacles;
    public Transform mouth, locationer;
    private float timer = 0;
    private int direction, locatedTentacle, choosedAngle;
    [HideInInspector]
    public int step = 0;
    private GameObject baronWheel;
    public void Attack_01(BossSense location)
    {
        switch (step)
        {
            case 0:
                timer += Time.deltaTime;
                if (timer >= maxDelayTime&&location.detect)
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
                tentacles.transform.localEulerAngles = new Vector3(0, choosedAngle, 0);
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
                tentacles.transform.localScale = new Vector3(1, 1, timer);
                if (timer == 1)
                {
                    timer = 0;
                    tentacles.transform.localScale = new Vector3(1, 1, 1);
                    step++;
                }
                break;
            case 3:
                if (timer < 90 && timer > -90)
                {
                    timer += Time.deltaTime * direction * attackSpeed;
                    tentacles.transform.localEulerAngles = new Vector3(0, choosedAngle + timer, 0);
                }
                else if (timer >= 90)
                {
                    timer = 90;
                    tentacles.transform.localEulerAngles = new Vector3(0, choosedAngle + timer, 0);
                    step++;
                }
                else if (timer <= -90)
                {
                    timer = -90;
                    tentacles.transform.localEulerAngles = new Vector3(0, choosedAngle + timer, 0);
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
                tentacles.transform.localScale = new Vector3(1, 1, timer);
                if (timer == 0)
                {
                    timer = 0;
                    tentacles.transform.localScale = new Vector3(1, 1, 0);
                    step = -1;
                }

                break;
        }
    }

    public void Attack_02(BossSense location)
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
                /*bullet.transform.position = bulletPosition.transform.position;
                rec = (movement.radium.objetive.transform.position - bulletPosition.transform.position).normalized;

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
                Instantiate(bullet);
                bullet.transform.position = new Vector3(0, 0, 0);
                bullet.transform.eulerAngles = new Vector3(0, 0, 0);
                */
                step = -1;
                break;

        }

    }


    public void Attack_05() // Como la 2
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
                if (timer >= maxDelayTime && location.detect)
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
                tentacles.transform.localEulerAngles = new Vector3(0, choosedAngle, 0);
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
                tentacles.transform.localScale = new Vector3(1, 1, timer);
                if (timer == 1)
                {
                    timer = 0;
                    tentacles.transform.localScale = new Vector3(1, 1, 1);
                    step++;
                }
                break;
            case 3:
                if (timer < 90 && timer > -90)
                {
                    timer += Time.deltaTime * direction * attackSpeed;
                    tentacles.transform.localEulerAngles = new Vector3(0, choosedAngle + timer, 0);
                }
                else if (timer >= 90)
                {
                    timer = 90;
                    tentacles.transform.localEulerAngles = new Vector3(0, choosedAngle + timer, 0);
                    step++;
                }
                else if (timer <= -90)
                {
                    timer = -90;
                    tentacles.transform.localEulerAngles = new Vector3(0, choosedAngle + timer, 0);
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
                tentacles.transform.localScale = new Vector3(1, 1, timer);
                if (timer == 0)
                {
                    timer = 0;
                    tentacles.transform.localScale = new Vector3(1, 1, 0);
                    step = -1;
                }

                break;
        }
    }

}
