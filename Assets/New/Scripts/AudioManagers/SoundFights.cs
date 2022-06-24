using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundFights : MonoBehaviour
{
    public int tensionSound, battleSound;
    [Tooltip("Son los sonidos normales del ambiente")]
    public int normalSound;
    public int tensionNumber;
    public bool battleLogic;
    private AudioSource audions;
    private Soundtracks sounds;
    // Start is called before the first frame update
    void Awake()
    {
        sounds = gameObject.GetComponent<Soundtracks>();
        audions = GameObject.Find("BackGroundMusic").GetComponent<AudioSource>();
        audions.clip = sounds.bgms[normalSound];
        audions.Play();
        tensionNumber = 0;
    }

    // Update is called once per frame
    void Update()
    {
        ConditionalSounds();
    }

    void ConditionalSounds()
    {
        if (tensionNumber == 0)
        {
            battleLogic = false;
        }
        else if(tensionNumber > 0 && !battleLogic)
        {

        }
        else if (tensionNumber > 0 && battleLogic)
        {

        }
    }
}
