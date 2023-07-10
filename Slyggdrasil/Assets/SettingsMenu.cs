using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class SettingsMenu : MonoBehaviour
{

    public AudioMixer audioMixer;
    public AudioManager audioManager;
    public Sound sound;

    private float volume;

    public void Awake()
    {
        audioManager = FindObjectOfType<AudioManager>();
    }

    public void SetVolume (float newVolume)
    {
        
        audioMixer.SetFloat("Volume", newVolume);
        sound.volume = newVolume;
        volume = newVolume;

    }

    public float GetVolume()
    {
        if (volume == 0.0f)
        {
            return 1.0f;
        }
        else if (volume < 0.0f && volume > -80.0f)
        {
            return 0.5f;
        }
        else if (volume == -80.0f)
        {
            return 0.0f;
        }
        else
        {
            return 0.0f;
        }
    }
}
