using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New UserData", menuName = "Data/UserData")]
public class UserData : ScriptableObject
{
    [Range(0.01f,100)]
    public float GenVolume = 0.01f;
    [Range(0.01f, 100)]
    public float MusicVolume = 0.01f;
    [Range(0.01f, 100)]
    public float SndVolume = 0.01f;

    public enum Lenguage
    {
        English,
        Español
    }

    public Lenguage actLeng;
    [Range(0.01f, 10)]
    public float aimSens=1;
}
