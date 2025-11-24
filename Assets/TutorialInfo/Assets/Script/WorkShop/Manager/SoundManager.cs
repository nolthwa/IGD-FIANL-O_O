using UnityEngine;
using System.Collections.Generic;

// กำหนดให้เป็น sealed เพื่อป้องกันการสืบทอด

public sealed class SoundManager : MonoBehaviour
{
    private static SoundManager _instance;
    public static SoundManager Instance
    {
        get
        {
            if (_instance == null)
                Debug.LogError("SoundManager Instance is NULL!");
            return _instance;
        }
    }

    [Header("Audio Sources")]
    public AudioSource musicSource;
    public AudioSource sfxSource;

    [Header("Default Audio Clips")]
    public AudioClip defaultButtonClick;
    public AudioClip defaultBackgroundMusic;

    private void Awake()
    {
        if (_instance == null)
        {
            _instance = this;
            DontDestroyOnLoad(gameObject);

            // Auto add audio sources if missing
            if (musicSource == null)
                musicSource = gameObject.AddComponent<AudioSource>();

            if (sfxSource == null)
                sfxSource = gameObject.AddComponent<AudioSource>();

            musicSource.loop = true;

            if (defaultBackgroundMusic != null)
                PlayMusic(defaultBackgroundMusic);
        }
        else if (_instance != this)
        {
            Destroy(gameObject);
        }
    }

    // --- Music ---
    public void PlayMusic(AudioClip clip)
    {
        if (clip == null) return;
        musicSource.clip = clip;
        musicSource.Play();
    }

    public void StopMusic()
    {
        musicSource.Stop();
    }

    // --- SFX ---
    public void PlaySFX(AudioClip clip)
    {
        if (clip == null) return;
        sfxSource.PlayOneShot(clip);
    }

    // --- Volume ---
    public void SetMusicVolume(float volume)
    {
        musicSource.volume = volume;
    }

    public void SetSFXVolume(float volume)
    {
        sfxSource.volume = volume;
    }
}