using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageOnTriger : MonoBehaviour
{
    public int damage;
    public string[] dmgTagsArray;
    public float timePerDmg;
    private float timer;
    private bool doDmg;

    // Start is called before the first frame update
    void Start()
    {
        timer = 0;
    }

    // Update is called once per frame
    void Update()
    {
        ReduceTime();
    }

    public void Damage(Collider other)
    {
        if(timer <= 0 && doDmg == true)
        {
            Debug.Log("Hit * to " + other.gameObject + "  " + damage);
            if(other.gameObject.GetComponent<Life>())
            {
                other.gameObject.GetComponent<Life>().ReduceLife(damage);
            }
            if(other.gameObject.GetComponent<EnemyLife>())
            {
                other.gameObject.GetComponent<EnemyLife>().ChangeLife(-damage);
            }
            timer = timePerDmg;
        }
    }

    void ReduceTime()
    {
        if (timer > 0)
        {
            timer -= Time.deltaTime;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
       
        for (int i = 0; i < dmgTagsArray.Length; i++)
        {
            if (other.gameObject.tag == dmgTagsArray[i])
            {
                doDmg = true;
                timer = 0;
                Damage(other);
            }
        }
    }

    private void OnTriggerStay(Collider other)
    {
        for (int i = 0; i < dmgTagsArray.Length; i++)
        {
            if (other.gameObject.tag == dmgTagsArray[i])
            {
                Damage(other);
            }
        }
    }
    private void OnTriggerExit(Collider other)
    {
        for (int i = 0; i < dmgTagsArray.Length; i++)
        {
            if (other.gameObject.tag == dmgTagsArray[i])
            {
                doDmg = false;
                timer = timePerDmg;
            }
        }
    }

    private void OnEnable()
    {
        timer = 0;
    }
}
