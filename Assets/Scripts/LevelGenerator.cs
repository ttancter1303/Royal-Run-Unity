using NUnit.Framework;
using System.Collections.Generic;
using UnityEngine;

public class LevelGenerator : MonoBehaviour
{
    [SerializeField] GameObject chunkPrefab;
    [SerializeField] int startingChunkAmount = 10;
    [SerializeField] Transform chunkParent;
    [SerializeField] float chunkLength = 10f;
    [SerializeField] float moveSpeed = 8f;

    List<GameObject> chunks = new List<GameObject>();
    private void Start()
    {
        SpawnStartingChunks();
    }
    private void Update()
    {
        MoveChunk();
    }
    private void SpawnStartingChunks()
    {
        for (int i = 0; i < startingChunkAmount; i++)
        {
            SpawnChunk();
        }
    }

    private void SpawnChunk()
    {
        float spawningPositionZ = CalculateSpawnPosZ();
        Vector3 chunkSpawnPos = new Vector3(transform.position.x, transform.position.y, spawningPositionZ);
        GameObject newChunk = Instantiate(chunkPrefab, chunkSpawnPos, Quaternion.identity, chunkParent);
        chunks.Add(newChunk);
    }

    private float CalculateSpawnPosZ()
    {
        float spawningPositionZ;
        if (chunks.Count == 0)
        {
            spawningPositionZ = transform.position.z;
        }
        else
        {
            spawningPositionZ = chunks[chunks.Count - 1].transform.position.z + chunkLength;
        }
        return spawningPositionZ;
    }
    void MoveChunk()
    {
        for (int i = 0; i < chunks.Count; i++)
        {
            GameObject chunk = chunks[i];
            chunk.transform.Translate(-transform.forward * (moveSpeed * Time.deltaTime));
            if(chunk.transform.position.z <= Camera.main.transform.position.z - chunkLength)
            {
                chunks.Remove(chunk);
                Destroy(chunk);

                SpawnChunk();
            }
        }
    }
}
