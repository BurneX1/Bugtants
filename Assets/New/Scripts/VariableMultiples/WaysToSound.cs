using UnityEngine;
[System.Serializable]
public class WaysToSound
{
    public int whatSound, whereSound;
    [HideInInspector]
    public SoundActive sounds;

    public void StopThenActive()
    {
        sounds.SoundStop(whereSound, whatSound);
        sounds.SoundPlay(whereSound, whatSound);
    }
    public void ActiveWhenStopped()
    {
        sounds.SoundPlay(whereSound, whatSound);
    }
    public void InstantStop()
    {
        sounds.SoundStop(whereSound, whatSound);
    }
}
