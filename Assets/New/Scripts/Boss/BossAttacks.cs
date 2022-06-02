using UnityEngine;

public class BossAttacks : MonoBehaviour
{
    public int damage;
    public float prepareSpeed, maxDelayTime, attackSpeed;
    public GameObject tentacles;

    private float timer = 0;
    private int step = 0, direction, locatedTentacle;
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
                tentacles.transform.localEulerAngles = new Vector3(0, 225 - 90 * locatedTentacle, 0);
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
                    timer = 0;
                    step++;
                break;
            case 3:
                timer += Time.deltaTime * direction;
                Vector3 looking = tentacles.transform.localEulerAngles;
                looking.y += timer;
                step++;
                break;
            case 4:

                step = 0;
                break;
        }
        /*
         Oscilaci�n por escala 
          Elegir que lado
         Atacar

         */


    }
    void InProcess()
    {

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
