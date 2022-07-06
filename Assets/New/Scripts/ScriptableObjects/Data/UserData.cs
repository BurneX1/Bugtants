using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New UserData", menuName = "Data/UserData")]
public class UserData : ScriptablePersistentObject
{
    [Range(0.01f,1)]
    public float genVolume = 0.01f;
    [Range(0.01f, 1)]
    public float musicVolume = 0.01f;
    [Range(0.01f, 1)]
    public float sndVolume = 0.01f;
    [Range(0.01f, 1)]
    public float spatialVolume = 0.01f;
    public enum Lenguage
    {
        English,
        Español
    }

    public enum Display
    {
        FullScreen,
        Windowed
    }

    public Lenguage actLeng;
    public Display displayMode;
    [Range(0.01f, 10)]
    public float aimSens=1;
}
