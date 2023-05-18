//Script to have obstacles spawn randomly from a spawner
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour
{

    [SerializeField]
    GameObject[] obstacle; //The objects we will be spawning
    [SerializeField]
    float existTime = 0.5f; //How long until the object is destroyed
    [SerializeField]
    float minTras; //The minimum x spawn position
    [SerializeField]
    float maxTras; //The maximum x spawn position

    void Awake()
    {
        StartCoroutine(ObstacleSpawn()); //Call the ienumerator
    }

    //Add a fixed update later so the obstacles are destroyed on player collisions

    IEnumerator ObstacleSpawn() //assign a function to the ienumerator
    {
        while(true)
        {
            var WANTED = Random.Range(minTras, maxTras); //Set up the x range that obstacles will spawn between
            var POSITION = new Vector3(WANTED, transform.position.y); //Set up the spawn location in the world
            GameObject gameObject = Instantiate(obstacle[Random.Range(0, obstacle.Length)], POSITION, Quaternion.identity); //Spawn the obstacle on the screen
            yield return new WaitForSeconds(existTime); //Wait a set time for the obstacle's existence
            Destroy(gameObject, 2.0f); //Destroy the object after a set time. Could use an editable variable to adjust the second value
        }
    }

}
    
            
        
    

