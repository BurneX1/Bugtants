using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossSummoners : MonoBehaviour
{
    public int damage, areaChoose, numberShoots;
    public float dropForce, stunDrop;
    [Tooltip("")]
    public GameObject eggBall;
    public GameObject mpEgg, lifeEgg;
    private GameObject[] area;
    private bool[] stock;
    [Tooltip("")]
    public int mothProb, beetleProb, wMothProb, expProb, stunProb;
    public GameObject moth, beetle, wMoth, exp, stun;
    // Start is called before the first frame update
    void Awake()
    {
        area = new GameObject[8];
        stock = new bool[8];
        for (int i = 0; i < area.Length; i++)
        {
            area[i] = GameObject.Find("BaronWheelSummon/Sum" + (i + 1));
            stock[i] = false;
        }

    }

    public void Summoners()
    {
        GameObject[] currency = new GameObject[area.Length];
        int probability = Random.Range(0, 2);
        if (probability == 0)
        {
            eggBall.GetComponent<DropBomb>().contain = mpEgg;
        }
        else if (probability == 1)
        {
            eggBall.GetComponent<DropBomb>().contain = lifeEgg;
        }
        probability = Random.Range(0, 10);
        stock[probability] = true;
        currency[probability] = eggBall;
        for (int i = 0; i < areaChoose; i++)
        {
            int count = Random.Range(0, 10);
            if (!stock[count])
            {
                stock[count] = true;
                probability = Random.Range(1, 101);
                currency[count].GetComponent<DropBomb>().contain = moth;
            }
            else
            {
                i--;
            }
        }
        eggBall.GetComponent<DropBomb>().force = dropForce;
        eggBall.GetComponent<DropBomb>().damage = damage;
        eggBall.GetComponent<DropBomb>().stunRate = stunDrop;


        for (int i = 0; i < area.Length; i++)
        {
            if (stock[i])
            {
                Vector3 look = area[i].transform.position;
                look.y += 10;
                eggBall.transform.position = look;
                Instantiate(eggBall);
                stock[i] = false;
            }
        }



    }
}
