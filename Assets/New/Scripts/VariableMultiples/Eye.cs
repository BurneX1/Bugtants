using System.Collections;
using System.Collections.Generic;

using UnityEngine;
public class Eye : MonoBehaviour
{
    public float eyeHealth;
    [HideInInspector]
    public float damageFeedTimer, immuneFeedTimer;
    [HideInInspector]
    public bool grandArmor, dead;
    [HideInInspector]
    public Material isImmuneMat, damagedMat, immuneMat, deadMat;
    private Material vulnerableMat;
    public BossEyes fatherEye;
    void Awake()
    {
        dead = false;
        vulnerableMat = GetComponent<MeshRenderer>().material;
    }
    public void ReduceHealth(float damageValue)
    {
        if (!dead)
        {
            if (!grandArmor)
            {
                eyeHealth -= damageValue;
                if (eyeHealth <= 0)
                {
                    GetComponent<MeshRenderer>().material = deadMat;
                    dead = true;
                    fatherEye.DeadEye();
                }
                else
                StartCoroutine(DamageFeedback());
            }
            else
            {
                StartCoroutine(ImmuneFeedback());
            }

        }

    }
    public void ChangeEyes(bool closed)
    {
        if (closed)
        {
            GetComponent<MeshRenderer>().material = isImmuneMat;
            //Tendria que tener una animacion de cerrando si lo esta haciendo:
            grandArmor = true;
        }
        else
        {

            GetComponent<MeshRenderer>().material = vulnerableMat;
            //Tendria que tener una animacion de abriendo si lo esta haciendo:
            grandArmor = false;

        }
    }
    IEnumerator DamageFeedback()
    {
        GetComponent<MeshRenderer>().material = damagedMat;
        yield return new WaitForSeconds(damageFeedTimer);
        if(!dead)
        GetComponent<MeshRenderer>().material = vulnerableMat;
    }
    IEnumerator ImmuneFeedback()
    {
        GetComponent<MeshRenderer>().material = immuneMat;
        yield return new WaitForSeconds(immuneFeedTimer);
        GetComponent<MeshRenderer>().material = isImmuneMat;
    }


}
