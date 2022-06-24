using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExploderView : MonoBehaviour
{
    public Animator anim;
    public float deadTime;
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

    }

    private void Dead()
    {
        if (cmp_rgdl) cmp_rgdl.RagdollSetActive(true);
        StartCoroutine(DesactiveOnTime(deadTime));
    }
    private void Damage()
    {
        if (anim) anim.SetTrigger("Dmg");
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
