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
    [HideInInspector]
    public WaysToSound waysTaken;
    public SoundsCapingVolume soundCapingOne;
    public AudioClip actClip, inactClip;
    [Header("On mortal egg")]
    [Range(0, 1)]
    public float capVolume;
    public AudioClip destroyedClip;
    public GameObject soundInstancer;

    // Start is called before the first frame update
    void Awake()
    {
        if (soundInstancer != null)
        {
            soundInstancer.GetComponent<SpawneableSFX>().capVolume = capVolume;
            soundInstancer.GetComponent<SpawneableSFX>().clippie = destroyedClip;
        }
        waysTaken.sounds = gameObject.GetComponent<SoundActive>();
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
                soundCapingOne.audSrc.clip = inactClip;
                soundCapingOne.audSrc.Play();
            }
            timeRevive += Time.deltaTime;
            if (timeRevive >= maxTimeRevive)
            {
                mesh.material = actualMat;
                spore.SetActive(true);
                c_life.AddLife(c_life.maxHealth);
                soundCapingOne.audSrc.clip = actClip;
                soundCapingOne.audSrc.Play();
                timeRevive = 0;
            }

        }
        else
        {
            soundInstancer.transform.position = transform.position;
            Instantiate(soundInstancer);
            gameObject.SetActive(false);
        }
    }
    public void Damaged()
    {
        waysTaken.whereSound = 0;
        waysTaken.whatSound = 0;
        waysTaken.StopThenActive();
    }
}