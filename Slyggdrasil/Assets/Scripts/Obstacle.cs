//Script to have obstacles spawn randomly from a spawner
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour
{

    [SerializeField]
    GameObject[] obstacle; //The objects we will be spawning
    [SerializeField]
    float existTime = 0.5f; //How long until a new object spawns
    [SerializeField]
    float detonateTime = 5.0f; //How long until object is destroyed
    [SerializeField]
    float minTras; //The minimum x spawn position
    [SerializeField]
    float maxTras; //The maximum x spawn position
    [SerializeField]
    float dropFromHeight = 0.0f; 

    void Awake()
    {
        
        StartCoroutine(ObstacleSpawn()); //Call the spawning ienumerator
    }

    //Add a fixed update later so the obstacles are destroyed on player collisions

    IEnumerator ObstacleSpawn() //assign a function to the ienumerator
    {
        while (true)
        {
            

            if(this.tag != "LateSpawning")
            {
                yield return new WaitForSeconds(existTime); //Wait a set time for the obstacle's existence
                var WANTED = Random.Range(minTras, maxTras); //Set up the x range that obstacles will spawn between
                var POSITION = new Vector3(WANTED, dropFromHeight); //Set up the spawn location in the world
                GameObject gameObject = Instantiate(obstacle[Random.Range(0, obstacle.Length)], POSITION, Quaternion.identity); //Spawn the obstacle on the screen
                yield return new WaitForSeconds(existTime); //Wait a set time for the obstacle's existence
                Destroy(gameObject, detonateTime); //Destroy the object after a set time. Could use an editable variable to adjust the second value
            }
            else
            {
                yield return new WaitForSeconds(existTime + 1.0f); //Wait a set time for the obstacle's existence
                var WANTED = Random.Range(minTras, maxTras); //Set up the x range that obstacles will spawn between
                var POSITION = new Vector3(WANTED, dropFromHeight); //Set up the spawn location in the world
                GameObject gameObject = Instantiate(obstacle[Random.Range(0, obstacle.Length)], POSITION, Quaternion.identity); //Spawn the obstacle on the screen
                yield return new WaitForSeconds(existTime+1.0f); //Wait a set time for the obstacle's existence
                Destroy(gameObject, detonateTime); 
            }
        }
    }


    

}
    
            
        
    

