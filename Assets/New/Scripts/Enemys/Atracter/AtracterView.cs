using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AtracterView : MonoBehaviour
{
    public Animator anim;
    private RagdolllActivator cmp_rgdl;
    private EnemyLife cmp_life;
    private EnemyAttract cmp_atr;


    private void Awake()
    {
        cmp_life = gameObject.GetComponent<EnemyLife>();
        cmp_rgdl = gameObject.GetComponent<RagdolllActivator>();
        cmp_atr = gameObject.GetComponent<EnemyAttract>();

    }

    // Update is called once per frame
    void Update()
    {
        anim.SetBool("Atract", cmp_atr.devouring);
    }

    private void Dead()
    {
        if (cmp_rgdl) cmp_rgdl.RagdollSetActive(true);
    }
    private void Damage()
    {
        if(cmp_atr.devouring == true)
        {
            anim.SetTrigger("DmgClose");
        }
        else
        {
            anim.SetTrigger("DmgOpen");
        }
    }
    private void OnEnable()
    {
        if (cmp_life && cmp_rgdl)
        {
            cmp_life.Dead += Dead;
            cmp_life.Damage += Damage;
        }
    }

    private void OnDisable()
    {
        if (cmp_life && cmp_rgdl)
        {
            cmp_life.Dead -= Dead;
            cmp_life.Damage -= Damage;
        }
    }
}
