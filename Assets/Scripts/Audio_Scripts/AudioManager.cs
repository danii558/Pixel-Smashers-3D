using UnityEngine;
using System.Collections.Generic;

public class AudioManager : MonoBehaviour
{
    public static AudioManager instance;

    [Header("Audio Sources")]
    public AudioSource musicSource;
    public AudioSource sfxSource;

    [Header("Music Clips")]
    public AudioClip musicBG;

    [Header("Audio Clips")]
    public AudioClip tapClip;
    public AudioClip shootClip;

    private float musicVolume = 1.0f;
    private float sfxVolume = 1.0f;

    private Dictionary<string, AudioClip> sfxClips;
    private Dictionary<string, AudioClip> musicClips;

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
        // Загружаем громкость при старте (с учетом диапазона от 0 до 100)
        musicVolume = PlayerPrefs.GetFloat("MusicVolume", 100f) / 100f;
        sfxVolume = PlayerPrefs.GetFloat("SFXVolume", 100f) / 100f;
        ApplyVolume();

        sfxClips = new Dictionary<string, AudioClip>
        {
            { "tap", tapClip },
            { "shoot", shootClip },
        };

        musicClips = new Dictionary<string, AudioClip>
        {
            { "music", musicBG }
        };
    }

    public void SetMusicVolume(float volume)
    {
        musicVolume = volume / 100f; // Преобразуем в диапазон 0-1
        PlayerPrefs.SetFloat("MusicVolume", volume); // Сохраняем в диапазоне 0-100
        ApplyVolume();
    }

    public void SetSFXVolume(float volume)
    {
        sfxVolume = volume / 100f; // Преобразуем в диапазон 0-1
        PlayerPrefs.SetFloat("SFXVolume", volume); // Сохраняем в диапазоне 0-100
        ApplyVolume();
    }

    private void ApplyVolume()
    {
        if (musicSource != null)
        {
            musicSource.volume = musicVolume;
        }

        if (sfxSource != null)
        {
            sfxSource.volume = sfxVolume;
        }
    }

    public void PlaySFX(string clipName)
    {
        if (sfxClips.ContainsKey(clipName))
        {
            sfxSource.PlayOneShot(sfxClips[clipName]);
        }
        else
        {
            Debug.LogWarning("Звуковой эффект с именем " + clipName + " не найден!");
        }
    }

    public void PlayMusic(string musicName)
    {
        StopMusic();

        if (musicClips.ContainsKey(musicName))
        {
            musicSource.clip = musicClips[musicName];
            musicSource.Play();
        }
        else
        {
            Debug.LogWarning("Музыкальный трек с именем " + musicName + " не найден!");
        }
    }

    public void StopMusic()
    {
        if (musicSource.isPlaying)
        {
            musicSource.Stop();
        }
    }
}
