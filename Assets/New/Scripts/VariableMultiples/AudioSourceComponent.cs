using UnityEngine;
[System.Serializable]
public class AudioSourceComponent
{
    [HideInInspector]
    public AudioSource audSrc;
    [HideInInspector]
    public GameObject newSound;
    [Tooltip("El GameObject que tenga AudioSource")]
    public GameObject location;
    [Tooltip("X es la distancia mínima del AudioSource y Y es la distancia máxima del AudioSource")]
    public Vector2 soundDistance;
}
