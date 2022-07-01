using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttract : MonoBehaviour
{
    private SoundFights audios;

    [HideInInspector]
    public GameObject player;
    public float speedSuction, damageRate;
    public int damage;
    [Tooltip("El sonido cuando es abierto")]
    public int whatOpenSound;
    private float timer, finalDestiny;

    public Transform initial, final;
    public EnemySense locate;
    public EnemyLife life;
    public Detecter signed;
    public bool devouring, mySwitch;
    private Vector3 downing;
    public BoxCollider hitBox;
    public WaysToSound waysIdle, waysStartVacuum, waysVacuum, waysAttack;
    // Start is called before the first frame update
    void Start()
    {
        audios = GameObject.Find("AudioManager").GetComponent<SoundFights>();
        mySwitch = false;
        life.armor = true;
        finalDestiny = final.transform.localPosition.z;
        devouring = false;
        player = GameObject.FindGameObjectWithTag("Player");
        if (gameObject.GetComponent<SoundActive>() != null)
        {
            waysIdle.sounds = gameObject.GetComponent<SoundActive>();
            waysStartVacuum.sounds = gameObject.GetComponent<SoundActive>();
            waysVacuum.sounds = gameObject.GetComponent<SoundActive>();
            waysAttack.sounds = gameObject.GetComponent<SoundActive>();
        }
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
            final.position = player.transform.position;
            Vector3 localPos;
            localPos.x = 0;
            localPos.y = 0;
            localPos.z = final.localPosition.z;
            final.localPosition = localPos;
            devouring = true;
            downing = localPos;
            waysIdle.InstantStop();
            waysStartVacuum.ActiveWhenStopped();
        }
        else if (locate.hear && signed.touch)
        {
            final.position = player.transform.position;
            Vector3 localPos;
            localPos.x = 0;
            localPos.y = 0;
            localPos.z = final.localPosition.z;
            final.localPosition = localPos;
            devouring = true;
            downing = localPos;
            downing.z = finalDestiny;
        }
        else
        {
            waysIdle.ActiveWhenStopped();
        }
    }

    void Devourer()
    {
        if (!mySwitch)
        {
            Debug.Log("+1");
            audios.tensionNumber += 1;
            mySwitch = true;
        }
        if (life.armor)
        {
            life.waysDamaged.whatSound = whatOpenSound;
            life.armor = false;
        }
        player.GetComponent<Movement>().poseser = gameObject;
        
        if (downing.z > finalDestiny)
        {
            downing.z -= speedSuction * Time.deltaTime;
            final.localPosition = downing;
            player.transform.position = final.position;
            waysVacuum.ActiveWhenStopped();
        }
        else if (downing.z < finalDestiny)
        {
            downing.z = finalDestiny;
            final.localPosition = downing;
            player.transform.position = final.position;
        }
        else
        {
            waysVacuum.InstantStop();
            timer += Time.deltaTime;
            if (timer >= damageRate)
            {
                player.GetComponent<Life>().ReduceLife(damage);
                waysAttack.StopThenActive();
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
