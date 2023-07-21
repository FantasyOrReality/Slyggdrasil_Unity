using UnityEngine;

public class AudioSettings : MonoBehaviour
{

    private static readonly string GameplayMusicPref = "GameplayMusicPref";

    private float gameplayMusicFloat;

    public AudioSource gameplayMusic;


    void Awake()
    {
        ContinueSettings();  
    }

    private void ContinueSettings()
    {
        gameplayMusicFloat = PlayerPrefs.GetFloat(GameplayMusicPref);

        gameplayMusic.volume = gameplayMusicFloat;

    }

}
