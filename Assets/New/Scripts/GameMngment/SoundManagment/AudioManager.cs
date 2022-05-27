using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;



public class AudioManager : MonoBehaviour
{
    public UserData userData;

    [SerializeField, Range(0.001f, 1f)] private float globalVolume = 0.5f;
    [SerializeField, Range(0.001f, 1f)] private float musicVolume = 0.5f;
    [SerializeField, Range(0.001f, 1f)] private float soundVolume = 0.5f;
    [SerializeField, Range(0.001f, 1f)] private float spatialVolume = 0.5f;
    [SerializeField] private Sound[] backgroundMusic;
    [SerializeField] private Sound[] fxMusic;
    [SerializeField] private Sound[] Sounds3D;
    [SerializeField] private AudioMixerGroup masterMixer;
    [SerializeField] private AudioMixerGroup backgroundMusicMixer;
    [SerializeField] private AudioMixerGroup soundFxMixer;
    [SerializeField] private AudioMixerGroup mixer3D;

    [HideInInspector]
    public static AudioManager instance;
    private AudioSource _defaultAudioSource;
    private AudioSource _sndFxAudioSource;
    private readonly Dictionary<string, AudioSource> _audioSources = new Dictionary<string, AudioSource>();
    private readonly Dictionary<string, Sound> _fxSounds = new Dictionary<string, Sound>();
    private readonly Dictionary<string, Sound> _3DSounds = new Dictionary<string, Sound>();

    private readonly Dictionary<string, AudioSource> _3DSources = new Dictionary<string, AudioSource>();

    protected void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }

        if(userData)
        {
            globalVolume = userData.genVolume;
            musicVolume = userData.musicVolume;
            soundVolume = userData.sndVolume;
            spatialVolume = userData.spatialVolume;
        }


        _sndFxAudioSource = gameObject.AddComponent<AudioSource>();
        _sndFxAudioSource.outputAudioMixerGroup = soundFxMixer;

        foreach (var sound in backgroundMusic)
        {
            var audioSource = GetAudioSource(sound);
            _audioSources.Add(sound.Name, audioSource);
            _defaultAudioSource = audioSource;
        }

        foreach (var fx in fxMusic)
        {
            _fxSounds.Add(fx.Name, fx);
        }

        foreach (var snd in Sounds3D)
        {
            _3DSounds.Add(snd.Name, snd);
        }
    }

    private AudioSource GetAudioSource(Sound sound)
    {
        var audioSource = gameObject.AddComponent<AudioSource>();
        audioSource.clip = sound.Clip;
        audioSource.volume = sound.Volume;
        audioSource.pitch = sound.Pitch;
        audioSource.loop = sound.Loop;
        audioSource.spatialBlend = sound.Spatial;
        return audioSource;
    }

    private void Update()
    {
        RefreshVolumes();
    }

    private void RefreshVolumes()
    {
        if (userData)
        {
            globalVolume = userData.genVolume;
            musicVolume = userData.musicVolume;
            soundVolume = userData.sndVolume;
            spatialVolume = userData.spatialVolume;
        }
        SetVolume("MasterVol", globalVolume);   //Master Update
        SetVolume("BgmVol", musicVolume);       //BGM Update
        SetVolume("SndVol", soundVolume);       //Snd Update
        SetVolume("3DVol", spatialVolume);       //Spatial Update
    }

    private void SetVolume(string volumeKey, float value)
    {
        masterMixer.audioMixer.SetFloat(volumeKey, Mathf.Log10(value) * 20);
    }

    public void Set3DSound(string soundName, GameObject obj)
    {
        if (!_3DSounds.ContainsKey(soundName))
        {
            Debug.LogError($"Music {soundName} does not exists.");
            return;
        }
        
        if (obj.gameObject.GetComponent<AudioSource>())
        {
            obj.gameObject.AddComponent<AudioSource>();
        }
        AudioSource src = obj.GetComponent<AudioSource>();
        src.clip = _3DSounds[soundName].Clip;
        src.volume = _3DSounds[soundName].Volume;
        src.clip = _3DSounds[soundName].Clip;
        src.pitch = _3DSounds[soundName].Pitch;
        src.loop = _3DSounds[soundName].Loop;
        src.spatialBlend = _3DSounds[soundName].Spatial;

        _3DSources.Add(obj.GetInstanceID() + src.name, src);
    }

    public void PlayBGM(string musicName)
    {
        if (!_audioSources.ContainsKey(musicName))
        {
            Debug.LogError($"Music {musicName} does not exists.");
            return;
        }

        _audioSources[musicName].Play();
    }

    public void PlayFx(string fxName)
    {
        if (!_fxSounds.ContainsKey(fxName))
        {
            Debug.LogError($"Fx {fxName} does not exists.");
            return;
        }

        var clip = _fxSounds[fxName].Clip;
        var volume = _fxSounds[fxName].Volume;
        _sndFxAudioSource.PlayOneShot(clip, volume);
    }

    public void PauseTheme(string musicName)
    {
        if (!_audioSources.ContainsKey(musicName))
        {
            Debug.LogError($"Music {musicName} does not exists.");
            return;
        }

        _audioSources[musicName].Pause();
    }

    public void Stop(string musicName)
    {
        if (!_audioSources.ContainsKey(musicName))
        {
            Debug.LogError($"Music {musicName} does not exists.");
            return;
        }

        _audioSources[musicName].Stop();
    }

    public void ResumeTheme(string musicName)
    {
        if (!_audioSources.ContainsKey(musicName))
        {
            Debug.LogError($"Music {musicName} does not exists.");
            return;
        }

        _audioSources[musicName].UnPause();
    }

    public bool DetectPlaying(string musicName)
    {
        if (_audioSources.ContainsKey(musicName)) return _audioSources[musicName].isPlaying;

        Debug.LogError($"Music {musicName} does not exists.");
        return false;
    }

    public void ChangeVolTo(string musicName, float value, float changeSpd)
    {
        if (!_audioSources.ContainsKey(musicName))
        {
            Debug.LogError($"Music {musicName} does not exists.");
            return;
        }

        var currentVolume = _audioSources[musicName].volume;
        if (Mathf.Approximately(currentVolume, value))
        {
            Debug.LogWarning($"Music {musicName} is already at volume {value}");
            return;
        }

        var sign = -Mathf.Sign(currentVolume - value);
        StartCoroutine(ChangeVol(_audioSources[musicName], value, changeSpd * sign));
    }

    private IEnumerator ChangeVol(AudioSource source, float value, float changeSpd)
    {
        if (value == 0)
        {
            value = 0.001f;
        }
        while (!Mathf.Approximately(source.volume, value))
        {
            source.volume += Time.deltaTime * changeSpd;

            if (Mathf.Approximately(Mathf.Sign(changeSpd), Mathf.Sign(source.volume - value)))
            {
                source.volume = value;
                break;
            }

            yield return null;
        }
    }
}

