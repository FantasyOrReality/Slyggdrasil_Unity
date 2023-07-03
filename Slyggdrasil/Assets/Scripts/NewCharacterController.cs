using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class NewCharacterController : MonoBehaviour
{
    [SerializeField]
    private int playerID = 0;

    private float movementSpeed = 1000.0f;

    Rigidbody2D rb;
    private float movement = 0.0f;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (playerID != 0)
        {
            if (playerID == 1)
            {
                movement = Input.GetAxis("Player1Horizontal")*movementSpeed;
                
            }
            else if (playerID == 2)
            {
                movement = Input.GetAxis("Player2Horizontal")*movementSpeed;

            }
        }
    }

    void FixedUpdate()
    {
        Vector2 velocity = rb.velocity;
        velocity.x = movement;
        rb.velocity = velocity;
    }
}
