using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossPatrolAttacks : MonoBehaviour
{
    public int[] firstPhase, secondPhase;
    public bool rage;
    private int contFirst, contSecond;
    [HideInInspector]
    public int numberNow;
    // Start is called before the first frame update
    void Awake()
    {
        rage = false;
        contFirst = 0;
        contSecond = 0;
    }



    public void NumberMulligan()
    {
        int number;
        if (!rage)
        {
            if (contFirst < firstPhase.Length)
            {
                number = firstPhase[contFirst];
                contFirst++;
            }
            else
            {
                number = Random.Range(1, 4);
            }
        }
        else
        {
            if (contSecond < secondPhase.Length)
            {
                number = secondPhase[contSecond];
                contSecond++;
            }
            else
            {
                number = Random.Range(1, 100);
                if (number <= 35)
                {
                    number = Random.Range(1, 4);
                }
                else
                {
                    number = Random.Range(4, 7);
                }
            }
        }

        numberNow = number;
    }


}
