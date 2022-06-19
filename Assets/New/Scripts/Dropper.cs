using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dropper : MonoBehaviour
{
    public bool isDropping;
    public DropBomb dropThing;
    public Detecter location;
    public float stunRate, force;
    public int damage;
    void Start()
    {
        dropThing.rigid.constraints = RigidbodyConstraints.FreezePositionY;
        dropThing.stunRate = stunRate;
        dropThing.force = force;
        dropThing.damage = damage;
        if (isDropping)
            Dropping();

    }


    void Update()
    {
        DropBool();
    }
    void DropBool()
    {
        if (location.touch)
        {
            Dropping();
        }
    }
    void Dropping()
    {
        dropThing.gameObject.transform.parent = null;
        dropThing.rigid.constraints = RigidbodyConstraints.None;
        dropThing.Awake();
        Destroy(gameObject);
    }
}
