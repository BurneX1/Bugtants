using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NegativeSpores : MonoBehaviour
{
    public int damage;
    public float delayDamage, maxTimeLife;
    private float delayTime, lifeTime;
    public Detecter playerSitting;
    public Vector2 colliderSize;
    public BoxCollider box;
    private Life playerLife;
    // Start is called before the first frame update
    void Awake()
    {
        playerLife = GameObject.FindGameObjectWithTag("Player").GetComponent<Life>();
        delayTime = 0;
        lifeTime = 0;
    }

    // Update is called once per frame
    void Update()
    {
        LookPlayer();
        LifeSpan();
    }

    void LookPlayer()
    {
        if (playerSitting.touch)
        {
            delayTime += Time.deltaTime;
            if (delayTime >= delayDamage)
            {
                playerLife.ReduceLife(damage);
                delayTime = 0;
            }
        }
        else
        {
            delayTime = 0;
        }
    }

    void LifeSpan()
    {
        lifeTime += Time.deltaTime;
        if (lifeTime >= maxTimeLife)
        {
            Destroy(gameObject);
        }
    }
    void OnDrawGizmos()
    {
        box.isTrigger = true;
        box.size = new Vector3(colliderSize.x, 2, colliderSize.y);
    }
}
