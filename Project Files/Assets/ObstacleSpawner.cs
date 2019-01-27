using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleSpawner : MonoBehaviour
{
    public GameObject[] obstacleSpawnPoints;
    public GameObject[] obstaclePrefabs;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(spawnObstacles());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private IEnumerator spawnObstacles()
    {
        while (true)
        {
            yield return new WaitForSeconds(Random.Range(2, 6));
            GameObject obstacle = GameObject.Instantiate(obstaclePrefabs[Random.Range(0, obstaclePrefabs.Length)],
                obstacleSpawnPoints[Random.Range(0, obstacleSpawnPoints.Length)].transform.position, Quaternion.identity);

            GameObject obstacle_2 = GameObject.Instantiate(obstaclePrefabs[Random.Range(0, obstaclePrefabs.Length)],
                obstacleSpawnPoints[Random.Range(0, obstacleSpawnPoints.Length)].transform.position, Quaternion.identity);
        }
        
    }
}
