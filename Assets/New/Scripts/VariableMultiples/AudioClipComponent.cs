using UnityEngine;
[System.Serializable]
public class AudioClipComponent
{
    [Tooltip("El GameObject que tenga AudioSource")]
    public AudioClip clip;
    [Tooltip("X es la distancia mínima del AudioSource y Y es la distancia máxima del AudioSource")]
    [Range(0,1)]
    public float capVolume;
}
