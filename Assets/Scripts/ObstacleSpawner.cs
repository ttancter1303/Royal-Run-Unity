using System.Collections;
using UnityEngine;

public class ObstacleSpawner : MonoBehaviour
{
    [SerializeField] GameObject[] obstaclePrefabs;
    [SerializeField] Transform obstaclesParent;
    [SerializeField] float obstacleSpawnTime = 1f;
    [SerializeField] float SpawnWidth = 4f;

    void Start()
    {
        StartCoroutine(SpawnObstacleRoutine()); 
    }

    IEnumerator SpawnObstacleRoutine()
    {
        while (true)
        {
            GameObject obstaclePrefab = obstaclePrefabs[Random.Range(0,obstaclePrefabs.Length)];
            Vector3 spawnPos = new Vector3(Random.Range(-SpawnWidth, SpawnWidth),transform.position.y,transform.position.z);
            yield return new WaitForSeconds(obstacleSpawnTime);
            Instantiate(obstaclePrefab, spawnPos, Random.rotation, obstaclesParent);
        }
    }
}
