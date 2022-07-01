using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Exploder : MonoBehaviour
{
    public EnemyGroundMove movement;
    public EnemyLife suicide;
    public GameObject suicidalBomb;
    public float timeLifeSpan;
    public int damage;
    [Tooltip("El sonido cuando es abierto")]
    public int whatExplodeSound;
    private bool done;
    // Start is called before the first frame update
    void Start()
    {
        done = false;
    }

    // Update is called once per frame
    void Update()
    {
        Explode();
    }

    void Explode()
    {
        if (movement.statNumber == 2)
        {
            suicidalBomb.transform.position = transform.position;
            suicidalBomb.GetComponent<LifeSpan>().maxTimer = timeLifeSpan;
            suicide.waysDead.whatSound = whatExplodeSound;
            suicide.ChangeLife(-suicide.life);
            if (!done)
            {
                movement.radium.objetive.GetComponent<Life>().ReduceLife(damage);
                done = true;
            }
            Instantiate(suicidalBomb);
        }

    }
}
