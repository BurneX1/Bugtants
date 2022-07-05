using UnityEngine;
[System.Serializable]
public class AudioClipComponent
{
    [Tooltip("El GameObject que tenga AudioSource")]
    public AudioClip clip;
    [Tooltip("Valor maximo del volumen")]
    [Range(0,1)]
    public float capVolume;
}
