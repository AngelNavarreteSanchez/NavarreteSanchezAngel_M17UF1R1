using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class SoundManagerScript : MonoBehaviour
{
    [DoNotSerialize]public static SoundManagerScript soundManagerScript;
    [Header("------------Audio Source --------------")]
    [SerializeField]AudioSource musicSource;
    [SerializeField] AudioSource sfxSource;

    [Header("------------Audio Clips -------------")]
    public AudioClip background;
    public AudioClip finalGameSound;
    public AudioClip attack;
    public AudioClip death;
    public AudioClip enemy;

    void Awake()
    {
        if (soundManagerScript == null)
        {
            soundManagerScript = this;
            DontDestroyOnLoad(gameObject);

        }
        else Destroy(gameObject);
    }
    public void Start()
    {
        musicSource.clip = background;
        musicSource.Play();
    }
    public void PlayFinalSong()
    {
        musicSource.Stop();
        musicSource.clip = finalGameSound;
        musicSource.Play();
    }
    public void PlaySFX(AudioClip audio) {
        sfxSource.PlayOneShot(audio);
    }
}
