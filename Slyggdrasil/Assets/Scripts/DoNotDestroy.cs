using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoNotDestroy : MonoBehaviour
{
    private void Awake()
    {
        GameObject[] gameMusicObj = GameObject.FindGameObjectsWithTag("Music");


        if (gameMusicObj.Length > 2)
        {
            Destroy(this.gameObject);
        }
        DontDestroyOnLoad(this.gameObject);


    }
}
