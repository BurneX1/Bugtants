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
        sdcpVol = genSld.value * sdcpSld.value / 10000;
        
        genTxt.text = genSld.value + "%";
        musTxt.text = musSld.value + "%";
        sndTxt.text = sndSld.value + "%";
        sdcpTxt.text = sdcpSld.value + "%";
        SoundChange();
    }

    public void SoundChange()
    {
        GameObject[] sfxUnits, bgmUnits, sdcpUnits;

        sfxUnits = GameObject.FindGameObjectsWithTag("SoundSFX");
        bgmUnits = GameObject.FindGameObjectsWithTag("SoundMusic");
        sdcpUnits = GameObject.FindGameObjectsWithTag("SoundCaping");
        for (int i = 0; i < sfxUnits.Length; i++)
        {
            if (sfxUnits[i].GetComponent<VolumeValue>() != null)
                sfxUnits[i].GetComponent<VolumeValue>().volValue = sndVol;
        }
        for (int i = 0; i < bgmUnits.Length; i++)
        {
            if (bgmUnits[i].GetComponent<VolumeValue>() != null)
                bgmUnits[i].GetComponent<VolumeValue>().volValue = musVol;
        }
        for (int i = 0; i < sdcpUnits.Length; i++)
        {
            if (sdcpUnits[i].GetComponent<VolumeValue>() != null)
                sdcpUnits[i].GetComponent<VolumeValue>().volValue = sdcpVol;
        }
    }
}
