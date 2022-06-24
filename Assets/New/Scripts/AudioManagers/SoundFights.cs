using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundFights : MonoBehaviour
{
    public int tensionSound, battleSound;
    public int tensionNumber, battleNumber;
    // Start is called before the first frame update
    void Awake()
    {
        tensionNumber = 0;
    }

    // Update is called once per frame
    void Update()
    {
        ConditionalSounds();
    }

    void ConditionalSounds()
    {

    }
}
