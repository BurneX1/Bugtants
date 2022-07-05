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
    [Range(0, 1)]
    public float capVolume;

    private AudioSource audions;
    private VolumeValue volumeScript;
    private Soundtracks sounds;
    // Start is called before the first frame update
    void Awake()
    {
        sounds = gameObject.GetComponent<Soundtracks>();
        volumeScript = GameObject.Find("BackGroundMusic").GetComponent<VolumeValue>();
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
        if (audions.volume != volumeScript.volValue * capVolume)
        audions.volume = volumeScript.volValue * capVolume;

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
