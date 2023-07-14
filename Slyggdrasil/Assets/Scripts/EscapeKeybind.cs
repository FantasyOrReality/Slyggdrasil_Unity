using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EscapeKeybind : MonoBehaviour
{
    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Cancel") == true)
        {
            Debug.Log("User Quit");
            Application.Quit();

        }
    }

    
}
