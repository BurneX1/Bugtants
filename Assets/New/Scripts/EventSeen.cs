using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventSeen : MonoBehaviour
{
    public GameObject[] location;
    public GameObject[] newLocation;
    public bool destroyable;
    private bool alt;
    public Detecter zoneA, zoneB;
    // Start is called before the first frame update
    void Start()
    {
        alt = false;
    }

    // Update is called once per frame
    void Update()
    {
        ZoneDetecter();
        if (location == null)
        { Debug.Log("N"); }
    }

    void ZoneDetecter()
    {
        if (zoneA.touch || zoneB.touch)
        {
            if (zoneA.touch)
            {
                alt = true;
            }
            else if (zoneB.touch)
            {
                alt = false;
            }
            if (destroyable)
            {
                if (alt = location != null)
                {
                    
                    for (int i = 0; i < location.Length; i++)
                    { Destroy(location[i]); }

                    for (int i =0;i<newLocation.Length;i++)
                    { newLocation[i].SetActive (true); }
                    
                }
            }
            else
            {
                if (alt)
                {
                    for (int i = 0; i < location.Length; i++)
                    { location[i].SetActive(true); }
                    
                    for (int i = 0; i < newLocation.Length; i++)
                    { newLocation[i].SetActive(false); }
                }
                else
                {
                    for (int i = 0; i < location.Length; i++)
                    { location[i].SetActive(false); }
                    for (int i = 0; i < newLocation.Length; i++)
                    { newLocation[i].SetActive(true); }
                }

            }
        }

    }
}
