using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventSeen : MonoBehaviour
{
    public GameObject location, newLocation;
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
                    Destroy(location);

                }
            }
            else
            {
                if (alt)
                {
                    location.SetActive(true);
                    newLocation.SetActive(false);
                }
                else
                {
                    location.SetActive(false);
                    newLocation.SetActive(true);
                }

            }
        }

    }
}
