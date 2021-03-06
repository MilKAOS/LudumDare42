﻿using UnityEngine;

public class AudioManager : MonoBehaviour {

    private AudioSource audioSource;
    private AudioClip explosionClip;
    private AudioClip scoreClip;

    private void Start()
    {        
        audioSource = GetComponent<AudioSource>();
    }

    public void DoAudioExplosion()
    {
        explosionClip = Resources.Load<AudioClip>(string.Format("{0}", GetExplosionSoundName()));
        audioSource.clip = explosionClip;
        audioSource.Play();
    }

    public void DoPlayAudio(string audioPath)
    {
        var clip = Resources.Load<AudioClip>(audioPath);
        audioSource.PlayOneShot(clip);
    }

    private string GetExplosionSoundName()
    {
        var rndSound = UnityEngine.Random.Range(0, 4);
        switch (rndSound)
        {
            case 0:
                return "Sounds/expl01";
            case 1:
                return "Sounds/expl02";
            case 2:
                return "Sounds/expl03";
            case 3:
                return "Sounds/expl04";
            default:
                throw new System.ArgumentException("sound missing");
        }
    }
}
