using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundScapeCaller : MonoBehaviour
{

    AudioManager aud;

    public string[] sndList;

    public float minTime;
    public float maxTime;

    public float timer;
    public float actWaiting;
    public string lastSnd;
    // Start is called before the first frame update
    void Start()
    {
        aud = GameObject.Find("AudioManager").GetComponent<AudioManager>();
        timer = 0;
        if (minTime <= 0 || maxTime <= 0)
        {
            minTime = 10;
            maxTime = 10;
        }
        RandomCall();
        actWaiting = Random.Range(minTime, maxTime);
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if (timer >= actWaiting)
        {
            RandomCall();
            timer = 0;
            actWaiting = Random.Range(minTime, maxTime);
        }
    }

    public void RandomCall()
    {

        if (sndList.Length > 0)
        {
            string tmp = sndList[Random.Range(0, sndList.Length - 1)];
            if (sndList.Length > 1)
            {
                int tmpNum = 0;
                while (tmp == lastSnd)
                {
                    tmp = sndList[Random.Range(0, sndList.Length - 1)];
                    tmpNum++;
                    if (tmpNum >= 3)
                    {
                        Debug.Log("xd");
                        return;

                    }
                    Debug.Log(tmp);
                }

            }

            if (aud)
            {
                aud.PlayFx(tmp);
            }
            lastSnd = tmp;
        }

    }
}
