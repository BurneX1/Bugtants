using UnityEngine;

public class BossAttacks : MonoBehaviour
{
    public int damage;
    public float prepareSpeed, maxDelayTime, attackSpeed;
    public GameObject tentacles;

    private float timer = 0;
    private int step = 0, direction, locatedTentacle, choosedAngle;
    [HideInInspector]
    
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
                else if(timer >= maxDelayTime)
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
                    step++;
                }
                break;
            case 3:
                if (timer < 90)
                {
                    timer += Time.deltaTime * direction * attackSpeed;
                    tentacles.transform.localEulerAngles = new Vector3(0, choosedAngle + timer, 0);
                }
                if (timer >= 90)
                {
                    timer = 90;
                    tentacles.transform.localEulerAngles = new Vector3(0, choosedAngle + timer, 0);
                    step++;
                }
                break;
            case 4:
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
                    step = 0;
                }           
                break;
        }
    }

    public void Attack_02()
    {

    }


    public void Attack_03()
    {

    }


    public void Attack_04()
    {

    }


    public void Attack_05()
    {

    }


    public void Attack_06()
    {

    }

}
