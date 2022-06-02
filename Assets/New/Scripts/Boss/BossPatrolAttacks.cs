using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossPatrolAttacks : MonoBehaviour
{
    public int[] firstPhase, secondPhase;
    public bool randomFirst, randomSecond;
    public int repeatFirst, repeatSecond;
    private int contFirst, contSecond;
    public int numberNow;
    // Start is called before the first frame update
    public void NumberMulligan()
    {



        numberNow = firstPhase[contFirst];
    }


}
