using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttract : MonoBehaviour
{
    [HideInInspector]
    public GameObject player;
    public float speedSuction, damageRate;
    public int damage;
    private float timer, finalDestiny;

    public Transform initial, final;
    public EnemySense locate;
    public EnemyLife life;
    public Detecter signed;
    public bool devouring;
    private Vector3 downing;
    public BoxCollider hitBox;
    // Start is called before the first frame update
    void Start()
    {
        finalDestiny = final.transform.localPosition.z;
        devouring = false;
        player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        if(!devouring)
        WaitingPlayer();
        else
        Devourer();
    }

    void WaitingPlayer()
    {
        if (locate.detect && signed.touch)
        {
            life.armor = true;
            final.position = player.transform.position;
            Vector3 localPos;
            localPos.x = 0;
            localPos.y = 0;
            localPos.z = final.localPosition.z;
            final.localPosition = localPos;
            devouring = true;
            downing = localPos;
        }
    }

    void Devourer()
    {
        life.armor = false;
        player.GetComponent<Movement>().poseser = gameObject;
        if (downing.z > finalDestiny)
        {
            downing.z -= speedSuction * Time.deltaTime;
            final.localPosition = downing;
            player.transform.position = final.position;
        }
        else if (downing.z < finalDestiny)
        {
            downing.z = finalDestiny;
            final.localPosition = downing;
            player.transform.position = final.position;
        }
        else
        {
            timer += Time.deltaTime;
            if (timer >= damageRate)
            {
                player.GetComponent<Life>().ReduceLife(damage);
                timer = 0;
            }

        }
    }

    void OnDrawGizmos()
    {
        hitBox.center = new Vector3(0, 0, locate.range/2);
        hitBox.size = new Vector3(0.1f, 0.1f, locate.range);
        final.transform.localPosition = new Vector3(0, 0, locate.quietRange);
    }
}
