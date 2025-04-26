using UnityEngine;

public class LevelGenerator : MonoBehaviour
{
    [SerializeField] GameObject chunkPrefab;
    [SerializeField] int startingChunkAmount = 10;
    [SerializeField] Transform chunkParent;
    [SerializeField] float chunkLength = 10f;
    [SerializeField] float moveSpeed = 8f;

    GameObject[] chunks = new GameObject[10];
    private void Start()
    {
        SpawnChunks();
    }
    private void Update()
    {
        MoveChunk();
    }
    private void SpawnChunks()
    {
        for (int i = 0; i < startingChunkAmount; i++)
        {
            float spawningPositionZ = CalculateSpawnPosZ(i);
            Vector3 chunkSpawnPos = new Vector3(transform.position.x, transform.position.y, spawningPositionZ);
            GameObject newChunk = Instantiate(chunkPrefab, chunkSpawnPos, Quaternion.identity, chunkParent);
            chunks[i] = newChunk;
            

        }
    }

    private float CalculateSpawnPosZ(int i)
    {
        float spawningPositionZ;
        if (i == 0)
        {
            spawningPositionZ = transform.position.z;
        }
        else
        {
            spawningPositionZ = transform.position.z + (i * chunkLength);
        }

        return spawningPositionZ;
    }
    void MoveChunk()
    {
        for (int i = 0; i < chunks.Length; i++)
        {
            chunks[i].transform.Translate(-transform.forward * (moveSpeed * Time.deltaTime));
            
        }
    }
}
