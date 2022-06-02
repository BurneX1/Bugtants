using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossPatrolAttacks : MonoBehaviour
{
    public int[] firstPhase, secondPhase;
    public int repeatFirst, repeatSecond;
    private int contFirst, contSecond;
    [HideInInspector]
    public int numberNow;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void NumberMulligan()
    {



        numberNow = firstPhase[contFirst];
    }


}
