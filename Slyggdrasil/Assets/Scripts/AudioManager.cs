//Script to manage audio and music with volume
using UnityEngine.Audio;
using System;
using UnityEngine;
using UnityEngine.SceneManagement;


public class AudioManager : MonoBehaviour
{
    public Sound[] sounds;
    public bool playing;

    public static AudioManager instance;
    // Start is called before the first frame update
    void Awake()
    {

        if (instance == null)
        {

            instance = this;
        }
        else
        {
            Destroy(gameObject);
            return;
        }

        DontDestroyOnLoad(gameObject);

        foreach (Sound s in sounds)
        {
            s.source = gameObject.AddComponent<AudioSource>();
            s.source.clip = s.clip;

            s.source.volume = s.volume;
            s.source.pitch = s.pitch;
            s.source.loop = s.loop;
        }

        Play("BackgroundMusic");


    }
    void Start()
    {
        Play("BackgroundMusic");


    }

    void Update()
    {
        foreach (Sound s in sounds)
        { 
            if (SceneManager.GetActiveScene().buildIndex < 1 || SceneManager.GetActiveScene().buildIndex > 5)
            {
                MuteAudio(true, s);
            }
            else
            {
                MuteAudio(false, s);
            }
        }
    }

    public void Play(string name)
    {
        
        Sound s = Array.Find(sounds, sound => sound.name == name);
        if (s == null)
        {
            Debug.LogWarning("Sound: " + name + " not found!");
            return;
        }
        if (playing)
        {
            s.source.Play();
            playing = false;
        }
    }

    public bool MuteAudio(bool mute, Sound s)
    {
        if (mute)
        {
            //s.source = gameObject.AddComponent<AudioSource>();
            s.volume = 0.0f;
            s.source.volume = s.volume;
            s.source.Pause();
            playing = false;
            return playing;


        }
        else
        {
            //s.source = gameObject.AddComponent<AudioSource>();
            s.volume = 100.0f;
            s.source.volume = s.volume;
            playing = true;
            return playing;

        }
    }
}
