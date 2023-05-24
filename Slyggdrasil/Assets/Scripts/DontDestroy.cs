using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DontDestroy : MonoBehaviour
{
    void Start()
    {
        //Keep this object between scenes
        GameObject.DontDestroyOnLoad(this.gameObject);
    }
}
