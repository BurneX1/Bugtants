using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlickeringLight : MonoBehaviour
{

    public Light _light;

    public float Mintime, MaxTime, Timer;
    public AudioSource _audioS;
    public AudioClip _lightaudio;

    public float _baseIntesity;

    public bool off;

    void Start()
    {
        off = false;
        Timer = MaxTime;
        _baseIntesity = _light.intensity;
    }

    void Update()
    {
        FlickerLight();
    }

    public void FlickerLight()
    {
        if (off)
        {
            if (Timer > 0)
            {
                Timer -= Time.deltaTime;
            }
            else if (Timer <= 0)
            {
                Timer = MaxTime;
                _light.intensity = _baseIntesity;
                off = false;
            }
        }
        else
        {
            if (Timer > 0)
            {
                Timer -= Time.deltaTime;
            }
            else if (Timer <= 0)
            {
                Timer = Mintime;
                _audioS.PlayOneShot(_lightaudio);
                _light.intensity = _baseIntesity / 2;
                off = true;
            }
        }
        
    }
}
