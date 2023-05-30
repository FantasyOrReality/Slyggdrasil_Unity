using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class DontDestroy : MonoBehaviour
{
    void Start()
    {
        if(SceneManager.GetActiveScene().buildIndex >=1 && SceneManager.GetActiveScene().buildIndex <=5)
        {
            //Keep this object between scenes
            GameObject.DontDestroyOnLoad(this.gameObject);
            //FindObjectOfType<AudioManager>().Play("Slyggdrasil_-_The_Climb");
        }
        
    }
}
