using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class CameraAdministration : MonoBehaviour
{

    public void CameraActivator(GameObject cam)
    {
        cam.SetActive(true);
    }

    public void CameraDeactivator(GameObject cam)
    {
        cam.SetActive(false);
    }
}
