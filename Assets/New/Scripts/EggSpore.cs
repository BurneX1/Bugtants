using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EggSpore : MonoBehaviour
{
    private Life c_life;
    public bool inmortal;
    public float maxTimeRevive;
    private float timeRevive;
    public Material matEgg;
    public GameObject spore;
    public MeshRenderer mesh;
    private Material actualMat;
    // Start is called before the first frame update
    void Start()
    {
        c_life = gameObject.GetComponent<Life>();
        actualMat = mesh.material;
    }

    // Update is called once per frame
    void Update()
    {
        if (c_life.actualHealth <= 0)
        {
            Die();
        }
    }

    private void Die()
    {
        if (inmortal)
        {
            if (mesh.material == actualMat)
            {
                mesh.material = matEgg;
                spore.SetActive(false);
            }
            timeRevive += Time.deltaTime;
            if (timeRevive >= maxTimeRevive)
            {
                timeRevive = 0;
                mesh.material = actualMat;
                spore.SetActive(true);
                c_life.AddLife(c_life.maxHealth);
            }

        }
        else
        {
            gameObject.SetActive(false);
        }
    }
}