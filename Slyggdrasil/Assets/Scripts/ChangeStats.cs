using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeStats : MonoBehaviour
{
    //Make the object exist
    [SerializeField]
    public GameObject gameObject;

    //Reference the controller script
    [SerializeField]
    CharacterController controllerReference;

    [SerializeField]
    public float editableJumpForce;

    

    void Awake()
    {
        editableJumpForce = controllerReference.m_JumpForce;


    }


    // Update is called once per frame
    void Update()
    {
        //Debug.Log(controllerReference.m_JumpForce);
        controllerReference.m_JumpForce = editableJumpForce;
    }

    //Detect collisions between the GameObjects with Colliders attached
    void OnCollisionEnter2D(Collision2D collision)
    {
        //Check for a match with the specified name on any GameObject that collides with your GameObject
        if (collision.gameObject.name == "PlaceholderIcePlatform1")
        {
            //If the GameObject's name matches the one you suggest, output this message in the console
            Debug.Log("Do something here");
            editableJumpForce = 1.0f;

        }

        //Check for a match with the specific tag on any GameObject that collides with your GameObject
        if (collision.gameObject.tag == "Ice")
        {
            //If the GameObject has the same tag as specified, output this message in the console
            Debug.Log("Change value to 1");
            editableJumpForce = 1.0f;
        }
    }

}
