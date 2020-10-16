using UnityEngine;
using System.Collections;
using System;

public class SoundManager : MonoBehaviour
{
   
    private static SoundManager instance;
    public static SoundManager Instance { get { return instance; } }

    [SerializeField]
    private AudioSource soundEffect;
    [SerializeField]
    private AudioSource soundMusic;
    [SerializeField]
    private SoundType[] SoundsArray;
    [SerializeField]
    private bool IsMute = false;
    [SerializeField]
    private float Volume = 1f;


    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        SetVolume(0.5f);
        PlayMusic(Sounds.Music);
    }

    public void Mute(bool status)
    {
        IsMute = status;
    }

    public void SetVolume(float volume)
    {
        Volume = volume;
        soundEffect.volume = Volume;
        soundMusic.volume = Volume;
    }
    public void PlayMusic(Sounds sound)
    {
        if (IsMute)
            return;
        AudioClip clip = getSoundClip(sound);
        if(clip !=null)
        {
            soundMusic.clip = clip;
            soundMusic.Play();
        }
        else
        {
            Debug.LogError("Clip didnt be found" + sound);
        }
    }
    public void Play(Sounds sound)
    {
        if (IsMute)
            return;
        AudioClip clip = getSoundClip(sound);
        if(clip !=null)
        {
            soundEffect.PlayOneShot(clip);
        }
        else
        {
            Debug.LogError("Clip didnt be found" + sound);
        }
    }

    private AudioClip getSoundClip(Sounds inputSound)
    {
        SoundType getSound = Array.Find(SoundsArray, item => item.soundType == inputSound);
        if(getSound != null)
        {
            return getSound.soundClip;
        }
        else
        {
            return null;
        }
    }

   
}

[Serializable]
public class SoundType
{
    public Sounds soundType;
    public AudioClip soundClip;
}
public enum Sounds
{
    ButtonClick,
    Music,
    PlayerMove,
    PlayerDeath,
    EnemyDeath,
}