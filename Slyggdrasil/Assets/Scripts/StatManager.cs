//Date started: 10/05/2023
//Date finished: Ongoing
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StatManager : MonoBehaviour
{
    //Reference the scripts
    [SerializeField]
    CharacterController controllerReference; //Character controller
    [SerializeField]
    PlatformEffectSetter platformEffectReference; //Script storing the base platform's jump value
    [SerializeField]
    PlatformIceEffectSetter platformIceEffectReference;
    [SerializeField]
    PlatformFakeEffectSetter platformFakeEffectReference;

    [SerializeField]
    private float editableJumpVelocity;

    //Specific jump values
    private float specificBaseJumpValue;
    private float specificIceJumpValue;
    [SerializeField]
    private float specificFakeJumpValue;

    

    void Awake()
    {
        editableJumpVelocity = controllerReference.m_JumpVelocity;
        specificBaseJumpValue = platformEffectReference.jumpValue;
        specificIceJumpValue = platformIceEffectReference.jumpValue;
        specificFakeJumpValue = platformFakeEffectReference.jumpValue;

    }


    // Update is called once per frame
    void FixedUpdate()
    {
        controllerReference.m_JumpVelocity = editableJumpVelocity;
        platformEffectReference.jumpValue = specificBaseJumpValue;
        platformIceEffectReference.jumpValue = specificIceJumpValue;
        platformFakeEffectReference.jumpValue = specificFakeJumpValue;
    }

    //Detect collisions between the GameObjects with Colliders attached
    void OnCollisionEnter2D(Collision2D collision)
    {
        //Check for a match with the specified name on any GameObject that collides with your GameObject
        //if (collision.gameObject.name == "PlaceholderIcePlatform1")
        //{
            //If the GameObject's name matches the one you suggest, output this message in the console
            //Debug.Log("Set by name");
           // editableJumpForce = 1.0f;

        //}

        if (collision.gameObject.tag == "Platform")
        {
            //Debug.Log("Set base by tag");
            editableJumpVelocity = specificBaseJumpValue;

        }

        if (collision.gameObject.tag == "Ice")
        {
            //If the GameObject has the same tag as specified, output this message in the console
            //Debug.Log("Set ice by tag");
            //editableJumpForce = 1.0f;
            editableJumpVelocity = specificIceJumpValue;


        }
    }

}
