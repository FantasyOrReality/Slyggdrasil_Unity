//Script to manage audio and music with volume
using UnityEngine.Audio;
using System;
using UnityEngine;
using UnityEngine.SceneManagement;


public class AudioManager : MonoBehaviour
{
    public Sound[] sounds;

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
            //s.source.PlayOnAwake = false;

            s.source.volume = s.volume;
            s.source.pitch = s.pitch;
            s.source.loop = s.loop;
        }

        Play("BackgroundMusic");

        
        
        //if (SceneManager.GetActiveScene().buildIndex <= 0 || SceneManager.GetActiveScene().buildIndex >= 6)
        //{
                //MuteAudio(true);

        //}
        //else
        //{
                //MuteAudio(false);
        //}
        

    }
    void Start()
    {
        //Play("BackgroundMusic");


    }

    void Update()
    {
        
    }

    public void Play(string name)
    {
        
        Sound s = Array.Find(sounds, sound => sound.name == name);
        if (s == null)
        {
            Debug.LogWarning("Sound: " + name + " not found!");
            return;
        }
        
            s.source.Play();
        
    }

    public void MuteAudio(bool mute)
    {
        if (mute)
        {
            //s.source = gameObject.AddComponent<AudioSource>();
            //s.volume = 0.0f;
            //s.source.volume = s.volume;
            Pause("BackgroundMusic");


        }
        else
        {
            //s.source = gameObject.AddComponent<AudioSource>();
            //s.volume = 100.0f;
            //s.source.volume = s.volume;
            Play("BackgroundMusic");
        }
    }

    public void Pause(string name)
    {
        Sound s = Array.Find(sounds, sound => sound.name == name);
        if (s == null)
        {
            Debug.LogWarning("Sound: " + name + " not found!");
            return;
        }

        s.source.Pause();
    }
}
