using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossTest : MonoBehaviour
{
    private InputSystemActions inputStm;
    private GameObject bossTester;
    void Awake()
    {
        bossTester = GameObject.Find("BossQueenBugtant");
        inputStm = new InputSystemActions();
        inputStm.BossTest._1.performed += _ => Determinate(1);
        inputStm.BossTest._2.performed += _ => Determinate(2);
        inputStm.BossTest._3.performed += _ => Determinate(3);
        inputStm.BossTest._4.performed += _ => Determinate(4);
        inputStm.BossTest._5.performed += _ => Determinate(5);
        inputStm.BossTest._6.performed += _ => Determinate(6);

    }
    void Determinate(int number)
    {
        if (bossTester.GetComponent<BossAttacks>().step == 0 && bossTester.GetComponent<BossPatrolAttacks>().numberNow == 0)
        {
            bossTester.GetComponent<BossPatrolAttacks>().numberNow = number;
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
