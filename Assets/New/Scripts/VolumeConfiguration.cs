using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VolumeConfiguration : MonoBehaviour
{
    public Slider genSld, musSld, sndSld, sdcpSld;
    public Text genTxt, musTxt, sndTxt, sdcpTxt;

    [HideInInspector]
    public float musVol, sndVol, sdcpVol;

    void Start()
    {
        VolumeModify();
    }

    public void VolumeModify()
    {
        musVol = genSld.value * musSld.value / 10000;
        sndVol = genSld.value * sndSld.value / 10000;
        //sdcpVol = genSld.value * sdcpSld.value / 10000;
        
        genTxt.text = genSld.value + "%";
        musTxt.text = musSld.value + "%";
        sndTxt.text = sndSld.value + "%";
        //sdcpTxt.text = sdcpSld.value + "%";
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
            //sfxUnits[i].GetComponent<AudioSource>().volume = sndVol * 10 / 10;
            if (sfxUnits[i].GetComponent<VolumeValue>() != null)
            sfxUnits[i].GetComponent<VolumeValue>().volValue = sndVol;
            //BgmUnits[i].GetComponent<AudioSource>().volume = musVol * 9 / 10;
        }
    }
}
