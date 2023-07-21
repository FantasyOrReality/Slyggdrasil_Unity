using UnityEngine;
using UnityEngine.UI;

public class AudioManagerNew : MonoBehaviour
{
    private static readonly string FirstPlay = "FirstPlay";
    private static readonly string GameplayMusicPref = "GameplayMusicPref";

    private int firstPlayInt;
    public Slider gameplayMusicSlider;
    private float gameplayMusicFloat;

    private AudioSource gameplayMusic;
    public GameObject musicObject;

    void Start()
    {
        gameplayMusic = musicObject.GetComponent<AudioSource>();

        firstPlayInt = PlayerPrefs.GetInt(FirstPlay);

        if(firstPlayInt == 0)
        {
            gameplayMusicFloat = 0.25f;
            gameplayMusicSlider.value = gameplayMusicFloat;
            PlayerPrefs.SetFloat(GameplayMusicPref, gameplayMusicFloat);
            PlayerPrefs.SetInt(FirstPlay, -1);
        }
        else
        {
            gameplayMusicFloat = PlayerPrefs.GetFloat(GameplayMusicPref);
            gameplayMusicSlider.value = gameplayMusicFloat;
        }
    }

    public void SaveSoundSettings()
    {
        PlayerPrefs.SetFloat(GameplayMusicPref, gameplayMusicSlider.value);

    }

    private void OnApplicationFocus(bool inFocus)
    {
        if (!inFocus)
        {
            SaveSoundSettings();
        }
    }

    public void UpdateSound()
    {
        gameplayMusic.volume = gameplayMusicSlider.value;
        
    }
}
