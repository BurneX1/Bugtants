using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossSummoners : MonoBehaviour
{
   
    public int damage, areaChoose;
    public float dropForce, stunDrop;
    private GameObject[] area;
    private bool[] stock;
    public int mothProb = 35, beetleProb = 25, wMothProb = 20, expProb = 12, stunProb = 8;
    public GameObject moth, beetle, wMoth, exp, stun;
    public GameObject eggBall;
    public GameObject mpEgg, lifeEgg;
    // Start is called before the first frame update
    void Awake()
    {
        area = new GameObject[10];
        stock = new bool[10];
        for (int i = 0; i < area.Length; i++)
        {
            area[i] = GameObject.Find("BaronWheelSummon/Sum" + (i + 1));
            stock[i] = false;
        }

    }

    public void Summoners()
    {
        GameObject[] currency = new GameObject[10];
        for (int i = 0; i < currency.Length; i++)
        {
            currency[i] = eggBall;
        }
        eggBall.GetComponent<DropBomb>().force = dropForce;
        eggBall.GetComponent<DropBomb>().damage = damage;
        eggBall.GetComponent<DropBomb>().stunRate = stunDrop;
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
        currency[probability] = eggBall;

        Vector3 looker = area[probability].transform.position;
        looker.y += 10;
        currency[probability].transform.position = looker;
        Instantiate(currency[probability]);
        stock[probability] = true;

        for (int i = 0; i < areaChoose; i++)
        {
            int count = Random.Range(0, 10);
            if (!stock[count])
            {
                probability = Random.Range(1, 101);
                if (probability >= 1 && probability < 1 + mothProb) // 1 a 35
                {
                    currency[count].GetComponent<DropBomb>().contain = moth;
                }
                else if (probability >= 1 + mothProb && probability < 1 + mothProb + beetleProb) //36 a 60
                {
                    currency[count].GetComponent<DropBomb>().contain = beetle;
                }
                else if (probability >= 1 + mothProb + beetleProb && probability < 1 + mothProb + beetleProb + wMothProb) //61 a 80
                {
                    currency[count].GetComponent<DropBomb>().contain = wMoth;
                }
                else if (probability >= 1 + mothProb + beetleProb + wMothProb && probability < 1 + mothProb + beetleProb + wMothProb + expProb) // 81 a 92
                {
                    currency[count].GetComponent<DropBomb>().contain = exp;
                }
                else if (probability >= 1 + mothProb + beetleProb + wMothProb + expProb && probability < 1 + mothProb + beetleProb + wMothProb + expProb + stunProb) // 93 a 100
                {
                    currency[count].GetComponent<DropBomb>().contain = stun;
                }
                Vector3 look = area[i].transform.position;
                look.y += 10;
                currency[i].transform.position = look;
                Instantiate(currency[i]);
                stock[count] = true;
            }
            else
            {
                i--;
            }
        }

        for (int i = 0; i < area.Length; i++)
        {
            if (stock[i])
            {
                stock[i] = false;
            }
        }



    }
}
