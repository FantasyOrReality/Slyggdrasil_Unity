using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StatManager : MonoBehaviour
{
    //Make the object exist
    //[SerializeField]
    //public GameObject gameObject;

    //Reference the scripts
    //[SerializeField]
    //CharacterController controllerReference;

    [SerializeField]
    CharacterController controllerReference;

    [SerializeField]
    public float editableJumpForce;

    [SerializeField]
    public float editableJumpVelocity;
    

    void Awake()
    {
        //editableJumpForce = controllerReference.m_JumpForce;
        editableJumpVelocity = controllerReference.m_JumpVelocity;

    }


    // Update is called once per frame
    void Update()
    {
        //Debug.Log(controllerReference.m_JumpForce);
        //controllerReference.m_JumpForce = editableJumpForce;

        controllerReference.m_JumpVelocity = editableJumpVelocity;
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
            Debug.Log("Set base by tag");
            editableJumpVelocity = 800.0f;
        }

        //Check for a match with the specific tag on any GameObject that collides with your GameObject
        if (collision.gameObject.tag == "Ice")
        {
            //If the GameObject has the same tag as specified, output this message in the console
            Debug.Log("Set ice by tag");
            //editableJumpForce = 1.0f;
            editableJumpVelocity = 1100.0f;

        }
    }

}
