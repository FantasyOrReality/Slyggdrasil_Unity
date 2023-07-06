using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmethystRocks : MonoBehaviour
{
    //Reference to pebbles
    public AmethystPebbles amethystPebblesRef;

    public Transform spawnPoint;

    [SerializeField]
    SpriteRenderer amethystRockSprite;
    [SerializeField]
    CircleCollider2D amethystRockCircleCollider;
    [SerializeField]
    BoxCollider2D amethystRockBoxCollider;

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
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        minTras = spawnPoint.position.x;
        maxTras = spawnPoint.position.x;
        spawnFromHeight = spawnPoint.position.y;

        //Spawn the contents
        StartCoroutine(SpawnAmethystPebbles());


        //Remove the object from the screen
        Destroy(amethystRockSprite);
        Destroy(amethystRockCircleCollider);
        Destroy(amethystRockBoxCollider);

    }

    IEnumerator SpawnAmethystPebbles()
    {
        var POSITION = new Vector3(rb.position.x, rb.position.y); //Set up the spawn location in the world


        GameObject gameObject = Instantiate(obstacle[Random.Range(0, obstacle.Length)], POSITION, Quaternion.identity); //Spawn the obstacle on the screen

        amethystPebblesRef.SetPosition(rb.position);
        amethystPebblesRef.SetVelocity(rb.velocity);
        
        yield return new WaitForSeconds(0); //Wait a set time for the obstacle's existence
        
        Destroy(gameObject, detonateTime); //Destroy the object after a set time. Could use an editable variable to adjust the second value
        //Destroy(gameObject2, detonateTime); //Destroy the object after a set time. Could use an editable variable to adjust the second value
        //Destroy(gameObject3, detonateTime); //Destroy the object after a set time. Could use an editable variable to adjust the second value



    }
}
