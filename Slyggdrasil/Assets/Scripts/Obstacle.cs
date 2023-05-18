using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour
{

    [SerializeField]
    GameObject[] obstacle;
    [SerializeField]
    float existTime = 0.5f;
    [SerializeField]
    float minTras;
    [SerializeField]
    float maxTras;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(ObstacleSpawn());
    }

    // Update is called once per frame
    void Update()
    {

    }

    IEnumerator ObstacleSpawn()
    {
        while(true)
        {
            var WANTED = Random.Range(minTras, maxTras);
            var POSITION = new Vector3(WANTED, transform.position.y);
            GameObject gameObject = Instantiate(obstacle[Random.Range(0, obstacle.Length)], POSITION, Quaternion.identity);
            yield return new WaitForSeconds(existTime);
            Destroy(gameObject, 2.0f);
        }
    }

}
    
            
        
    

