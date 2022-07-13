using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemMagnet : MonoBehaviour
{
    public GameObject bossVacuum;
    private GameObject player;
    public float radius, speedBoss, speedPlayer, time;
    private Vector3 angler, hooker, rec;
    [HideInInspector]
    public bool bell;
    [Header("Untouchables")]
    public SphereCollider collideObj;
    public Detecter detectPlayer;
    private Rigidbody rigid;
    private bool lockers = false;

    // Start is called before the first frame update
    void Awake()
    {
        //transform.gameObject.tag = "Item";
        lockers = true;
        rigid = GetComponent<Rigidbody>();
        player = GameObject.FindGameObjectWithTag("Player");
        bossVacuum = GameObject.Find("Boss");
        if (bossVacuum != null)
        {
            rec = (bossVacuum.transform.position - transform.position).normalized;
            rec.y = 0;
            angler = new Vector3(rec.x, rec.y, rec.z);
        }
    }

    // Update is called once per frame
    void Update()
    {
        Conditionals();
    }
    void Conditionals()
    {
        if (detectPlayer.touch)
        {
            VacuumPlayer();
        }
        else if (bell && bossVacuum != null)
        {
            StartCoroutine(VacuumTime());
        }
        else if (!detectPlayer.touch)
        {
            StopVacuum();
        }
    }
    void VacuumPlayer()
    {
        rec = (player.transform.position - transform.position).normalized;
        hooker = new Vector3(rec.x, rec.y, rec.z);
        rigid.velocity = new Vector3(hooker.x * speedPlayer, hooker.y * speedPlayer, hooker.z * speedPlayer);
    }
    IEnumerator VacuumTime()
    {
        rigid.velocity = new Vector3(angler.x * speedBoss, angler.y * speedBoss, angler.z * speedBoss);
        yield return new WaitForSeconds(time);
        bell = false;
        if (!detectPlayer.touch)
            rigid.velocity = new Vector3(0, 0, 0);
    }
    void StopVacuum()
    {
        rigid.velocity = new Vector3(0, 0, 0);
    }
    void OnDrawGizmos()
    {
        if(!lockers)
        collideObj.radius = radius;
    }
}
