using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VolumeConfiguration : MonoBehaviour
{
    public Slider genSld, musSld, sndSld;
    [HideInInspector]
    public float musVol, sndVol;
    public Text genTxt, musTxt, sndTxt;

    public void VolumeModify()
    {
        musVol = genSld.value * musSld.value / 10000;
        sndVol = genSld.value * sndSld.value / 10000;

        genTxt.text = genSld.value + "%";
        musTxt.text = musSld.value + "%";
        sndTxt.text = sndSld.value + "%";
        SoundChange();
    }

    void SoundChange()
    {
        GameObject[] sfxUnits;

        sfxUnits = GameObject.FindGameObjectsWithTag("SoundSFX");

        for(int i = 0; i < sfxUnits.Length; i++)
        {
            sfxUnits[i].GetComponent<AudioSource>().volume = sndVol*9/10;
        }
    }
}
