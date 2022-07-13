using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StunerView : MonoBehaviour
{
    public Animator anim;
    public float deadTime;
    private RagdolllActivator cmp_rgdl;
    private EnemyLife cmp_life;
    private EnemyGroundMove cmp_enm;
    private MeleeAttack cmp_atck;
    private MaterialChanger cmp_mat;

    private void Awake()
    {
        cmp_life = gameObject.GetComponent<EnemyLife>();
        cmp_rgdl = gameObject.GetComponent<RagdolllActivator>();
        cmp_enm = gameObject.GetComponent<EnemyGroundMove>();
        cmp_atck = gameObject.GetComponent<MeleeAttack>();
        cmp_mat = gameObject.GetComponent<MaterialChanger>();
    }
    // Start is called before the first frame update
    void Start()
    {
        if (cmp_rgdl) cmp_rgdl.RagdollSetActive(false);

    }

    // Update is called once per frame
    void Update()
    {
        anim.SetBool("Spd", cmp_enm.moving);
        if (cmp_enm.stat == EnemyGroundMove.Status.chasing)
        {
            anim.SetBool("Run", true);
        }
        else
        {
            anim.SetBool("Run", false);
        }

        //anim.SetBool("Atack", cmp_enm.attacking);
    }

    private void Dead()
    {
        if (cmp_rgdl) cmp_rgdl.RagdollSetActive(true);
        if (cmp_mat) cmp_mat.ExpossureChange(1);

        StartCoroutine(DesactiveOnTime(deadTime));
    }
    private void Atack()
    {
        anim.SetTrigger("Atack");
    }
    private void OnEnable()
    {
        if (cmp_life && cmp_rgdl)
        {

            cmp_life.Dead += Dead;
        }
        if (cmp_atck) cmp_atck.Atack += Atack;

    }

    private void OnDisable()
    {
        if (cmp_life && cmp_rgdl)
        {
            cmp_life.Dead -= Dead;
        }
        if (cmp_atck) cmp_atck.Atack -= Atack;
    }

    IEnumerator DesactiveOnTime(float time)
    {
        yield return new WaitForSeconds(time);
        gameObject.SetActive(false);
    }
}
