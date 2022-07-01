using UnityEngine;
[System.Serializable]
public class AudioClipComponent
{
    [Tooltip("El GameObject que tenga AudioSource")]
    public AudioClip clip;
    [Tooltip("X es la distancia m�nima del AudioSource y Y es la distancia m�xima del AudioSource")]
    [Range(0,1)]
    public float capVolume;
}
