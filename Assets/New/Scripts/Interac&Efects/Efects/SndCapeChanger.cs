using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SndCapeChanger : MonoBehaviour
{
    public string[] newSndList;
    public SoundScapeCaller sndScape;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ChangeSoundScape()
    {
        if(sndScape)
        {
            sndScape.sndList = newSndList;
        }
    }
}
