using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeAttack : MonoBehaviour
{
    public EnemyGroundMove movement;
    public float maxTimer;
    [HideInInspector]
    public bool stunned;
    public int damage;
    private float timer;
    private SoundActive sounds;
    // Start is called before the first frame update
    void Start()
    {
        stunned = false;
        if (gameObject.GetComponent<SoundActive>() != null)
        {
            sounds = gameObject.GetComponent<SoundActive>();
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (!stunned)
        Attack();
    }
    void Attack()
    {
        timer += Time.deltaTime;
        if (timer >= maxTimer && (movement.statNumber == 2 || movement.statNumber == 3))
        {
            // Eso es en donde activa los sonidos si tiene sonidos insertados
            if (sounds != null)
            {
                sounds.SoundStop(0);
                sounds.SoundPlay(0);
            }
            Debug.Log("Attacked");
            movement.radium.objetive.GetComponent<Life>().ReduceLife(damage);
            timer = 0;
        }
    }
}
