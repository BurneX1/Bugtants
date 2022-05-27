using UnityEngine;

[System.Serializable]
public class Sound
{
    [SerializeField] public string name;
    [SerializeField] private AudioClip clip;
    [SerializeField] private bool loop;
    [SerializeField, Range(0.0f, 1f)] private float spatial = 0f;
    [SerializeField, Range(0.001f, 1f)] private float volume = 1f;
    [SerializeField, Range(0.001f, 1f)] private float pitch = 1f;

    public string Name => name;
    public AudioClip Clip => clip;
    public bool Loop => loop;
    public float Spatial => spatial;
    public float Volume => volume;
    public float Pitch => pitch;
}