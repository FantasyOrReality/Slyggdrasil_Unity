using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CountCollisions : MonoBehaviour
{

    int collisionNumber;
    string collisionString;


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "CounterTrigger")
        {
            collisionNumber = collisionNumber + 1;
            collisionString = collisionNumber.ToString();
            Debug.Log("Collisions detected: " + collisionString);
        }
    }
}
