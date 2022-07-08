using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AtracterView : MonoBehaviour
{
    public Animator anim;
    public float deadTime;
    private RagdolllActivator cmp_rgdl;
    private EnemyLife cmp_life;
    private EnemyAttract cmp_atr;
    private MaterialChanger cmp_mat;

    private void Awake()
    {
        cmp_life = gameObject.GetComponent<EnemyLife>();
        cmp_rgdl = gameObject.GetComponent<RagdolllActivator>();
        cmp_atr = gameObject.GetComponent<EnemyAttract>();
        cmp_mat = gameObject.GetComponent<MaterialChanger>();

    }

    private void Start()
    {
        if (cmp_rgdl) cmp_rgdl.RagdollSetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        anim.SetBool("Atract", cmp_atr.devouring);
    }

    private void Dead()
    {
        if (cmp_rgdl) cmp_rgdl.RagdollSetActive(true);
        if (cmp_mat) cmp_mat.ExpossureChange(1);
        StartCoroutine(DesactiveOnTime(deadTime));
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
    IEnumerator DesactiveOnTime(float time)
    {
        yield return new WaitForSeconds(time);
        gameObject.SetActive(false);
    }
}
