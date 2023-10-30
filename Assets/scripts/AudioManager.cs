using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    [Header("------Sources------")]
    [SerializeField] AudioSource musicSource;
    [SerializeField] AudioSource sfxSource;

    [Header("------Audio Clips------")]
    public AudioClip bgm;
    public AudioClip sfx;

    private void Start()
    {
        musicSource.clip = bgm;
        musicSource.Play();
    }
}
