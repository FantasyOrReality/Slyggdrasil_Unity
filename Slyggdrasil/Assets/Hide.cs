using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Hide : MonoBehaviour
{
    public static Hide instance;


    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
        DontDestroyOnLoad(gameObject);

        if (SceneManager.GetActiveScene().name == "OptionsMenu")
        {
            UnHideObject(instance.gameObject);
        }
        else if (SceneManager.GetActiveScene().name != "OptionsMenu")
        {
            HideObject(instance.gameObject);
        }
    }

    public void FixedUpdate()
    {
        if(SceneManager.GetActiveScene().name == "OptionsMenu")
        {
            UnHideObject(instance.gameObject);
        }
        else if (SceneManager.GetActiveScene().name != "OptionsMenu")
        {
            HideObject(instance.gameObject);
        }
    }

    public void UnHideObject(GameObject gameObject)
    {
        gameObject.SetActive(true);
    }

    public void HideObject(GameObject gameObject)
    {
        gameObject.SetActive(false);

    }
}
