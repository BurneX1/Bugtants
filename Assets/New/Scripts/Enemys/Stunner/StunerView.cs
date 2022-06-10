using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StunerView : MonoBehaviour
{
    public Animator anim;
    private RagdolllActivator cmp_rgdl;
    private EnemyLife cmp_life;
    private EnemyGroundMove cmp_enm;

    private void Awake()
    {
        cmp_life = gameObject.GetComponent<EnemyLife>();
        cmp_rgdl = gameObject.GetComponent<RagdolllActivator>();
        cmp_enm = gameObject.GetComponent<EnemyGroundMove>();
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

        anim.SetBool("Atack", cmp_enm.attacking);
    }

    private void Dead()
    {
        if (cmp_rgdl) cmp_rgdl.RagdollSetActive(true);
    }
    private void OnEnable()
    {
        if (cmp_life && cmp_rgdl)
        {
            cmp_life.Dead += Dead;
        }

    }

    private void OnDisable()
    {

    }
}
