using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class DontDestroy : MonoBehaviour
{

    public static DontDestroy instance;


    void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
            return;
        }
        else
        {
            if (this.transform.name == instance.name)
            {
                Destroy(gameObject);

            }
            else
            {
                instance = this;
            }
            DontDestroyOnLoad(gameObject);
            return;
        }
        //DontDestroyOnLoad(gameObject);
    }
}
