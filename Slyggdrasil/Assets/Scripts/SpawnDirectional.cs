using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnDirectional : MonoBehaviour
{
    public Transform spawnPoint;

    [SerializeField]
    private bool active = true;
    private bool spawnsOnLeft = true;

    [SerializeField]
    private int spawnPriority;
    private float spawnDelay = 0.5f;

    [SerializeField]
    GameObject[] obstacle; //The objects we will be spawning
    [SerializeField]
    float existTime = 0.5f; //How long until a new object spawns
    float detonateTime = 1.0f; //How long until object is destroyed
    float minTras; //The minimum x spawn position
    float maxTras; //The maximum x spawn position
    float spawnFromHeight = 0.0f;

    private void Start()
    {
        minTras = spawnPoint.position.x;
        maxTras = spawnPoint.position.x;
        spawnFromHeight = spawnPoint.position.y;
    }

    private void Awake()
    {
        //Choose spawn direction
        if(this.tag == "SpawnFromLeft")
        {
            SetSpawnDirection(true);
        }
        else if(this.tag == "SpawnFromRight")
        {
            SetSpawnDirection(false);
        }

        //Choose when to spawn
        StartCoroutine(ObstacleSpawn());
    }

    // Update is called once per frame
    void Update()
    {
        

    }

    //Public setters
    public void SetSpawnDirection(bool spawnsOnLeftSetter)
    {
        spawnsOnLeft = spawnsOnLeftSetter;
    }

    //Public getters
    public bool GetSpawnDirection()
    {
        return spawnsOnLeft;
    }

    IEnumerator ObstacleSpawn() //assign a function to the ienumerator
    {
        while(active)
        {
            yield return new WaitForSeconds(existTime+ ((spawnPriority-1)*spawnDelay)); //Wait a set time for the obstacle's existence
            var WANTED = Random.Range(minTras, maxTras); //Set up the x range that obstacles will spawn between
            var POSITION = new Vector3(WANTED, spawnFromHeight); //Set up the spawn location in the world
            GameObject gameObject = Instantiate(obstacle[Random.Range(0, obstacle.Length)], POSITION, Quaternion.identity); //Spawn the obstacle on the screen
            yield return new WaitForSeconds(existTime); //Wait a set time for the obstacle's existence
            Destroy(gameObject, detonateTime); //Destroy the object after a set time. Could use an editable variable to adjust the second value
        }
    }

    

}
