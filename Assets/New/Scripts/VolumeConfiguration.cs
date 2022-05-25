using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VolumeConfiguration : MonoBehaviour
{
    public Slider genSld, musSld, sndSld;
    public Text genTxt, musTxt, sndTxt;

    [HideInInspector]
    public float musVol, sndVol;

    void Start()
    {
        VolumeModify();
    }

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
        //GameObject[] BgmUnits;

        sfxUnits = GameObject.FindGameObjectsWithTag("SoundSFX");
        //BgmUnits = GameObject.FindGameObjectsWithTag("SoundMusic");
        for (int i = 0; i < sfxUnits.Length; i++)
        {
            sfxUnits[i].GetComponent<AudioSource>().volume = sndVol * 9 / 10;
            //BgmUnits[i].GetComponent<AudioSource>().volume = musVol * 9 / 10;
        }
    }
}
