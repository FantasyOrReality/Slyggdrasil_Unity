using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fireball : MonoBehaviour
{
    public SpawnDirectional spawnDirectionalRef;

    public float speed = 2000.0f;
    public Rigidbody2D rb;
    // Start is called before the first frame update
    void Start()
    {
        if(spawnDirectionalRef.GetSpawnDirection() == true)
        {
            rb.velocity = transform.right * speed;
        }
        else
        {
            rb.velocity = -(transform.right) * speed;

        }
    }
}
