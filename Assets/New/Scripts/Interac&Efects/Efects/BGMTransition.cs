using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGMTransition : MonoBehaviour
{
    private AudioManager aud;
    public string PlayBGM;
    // Start is called before the first frame update
    void Start()
    {
        aud = GameObject.Find("AudioManager").GetComponent<AudioManager>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ChangeBGM()
    {
        //aud.
    }
}
