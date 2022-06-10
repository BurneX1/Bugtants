using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeetleBombView : MonoBehaviour
{
    public Animator anim;
    private RagdolllActivator cmp_rgdl;
    private EnemyLife cmp_life;

    private void Awake()
    {
        cmp_life = gameObject.GetComponent<EnemyLife>();
        cmp_rgdl.gameObject.GetComponent<RagdolllActivator>();
    }
    // Start is called before the first frame update
    void Start()
    {
        if (cmp_rgdl) cmp_rgdl.RagdollSetActive(false);

    }

    // Update is called once per frame
    void Update()
    {

    }

}