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
    [Tooltip("X es la distancia m�nima del AudioSource y Y es la distancia m�xima del AudioSource")]
    public Vector2 soundDistance;
}
