using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmethystPebbles : MonoBehaviour
{
    [SerializeField]
    public AmethystRocks amethystRocksRef;

    public Rigidbody2D rb;
    public UnityEngine.Vector2 speed;
    [SerializeField]


    public void SetPosition(Vector2 newPosition)
    {
        rb.position = newPosition;
    }
    public void SetVelocity(UnityEngine.Vector2 newVelocity)
    {
        rb.velocity = newVelocity;
    }
}
