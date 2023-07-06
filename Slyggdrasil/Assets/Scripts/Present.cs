using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Present : MonoBehaviour
{
    public SpawnDirectional spawnDirectionalRef;
    public PresentContents presentContentsRef;

    public Transform spawnPoint;

    [SerializeField]
    SpriteRenderer presentSprite;
    [SerializeField]
    CircleCollider2D presentCollider2D;


    [SerializeField]
    GameObject[] obstacle; //The objects we will be spawning
    [SerializeField]
    float existTime = 0.5f; //How long until a new object spawns
    float detonateTime = 1.0f; //How long until object is destroyed
    float minTras; //The minimum x spawn position
    float maxTras; //The maximum x spawn position
    float spawnFromHeight = 0.0f;

    public float speed = 2000.0f;
    public Rigidbody2D rb;
    // Start is called before the first frame update
    void Start()
    {
        if (spawnDirectionalRef.GetSpawnDirection() == true)
        {
            rb.velocity = transform.right * speed;
        }
        else
        {
            rb.velocity = -(transform.right) * speed;

        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        minTras = spawnPoint.position.x;
        maxTras = spawnPoint.position.x;
        spawnFromHeight = spawnPoint.position.y;

        //Spawn the contents
        StartCoroutine(SpawnPresentContent());

        //Remove the object from the screen
        Destroy(presentSprite);
        Destroy(presentCollider2D);
    }

    IEnumerator SpawnPresentContent()
    {
        var POSITION = new Vector3(rb.position.x, rb.position.y); //Set up the spawn location in the world
        GameObject gameObject = Instantiate(obstacle[Random.Range(0, obstacle.Length)], POSITION, Quaternion.identity); //Spawn the obstacle on the screen
        presentContentsRef.SetPosition(rb.position);
        presentContentsRef.SetVelocity(rb.velocity);
        yield return new WaitForSeconds(existTime); //Wait a set time for the obstacle's existence
        Destroy(gameObject, detonateTime); //Destroy the object after a set time. Could use an editable variable to adjust the second value
    }
}
