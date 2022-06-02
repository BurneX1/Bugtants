using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlickeringLight : MonoBehaviour
{

    public Light[] _light;

    public float Mintime, MaxTime, Timer;
    public AudioSource _audios;
    public AudioClip _lightaudio;

    public float _baseIntesity;

    public bool off;

    void Start()
    {
        off = false;
        Timer = MaxTime;
        for (int i = 0; i < _light.Length; i++)
        {
            _baseIntesity = _light[i].intensity;
        }
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
                for (int i = 0; i < _light.Length; i++)
                {
                    _light[i].intensity = _baseIntesity;
                }
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

                _audios.PlayOneShot(_lightaudio, 0.6f);
                for (int i = 0; i < _light.Length; i++)
                {
                    _light[i].intensity = _baseIntesity / 2;
                }
                off = true;
            }
        }

    }
}
