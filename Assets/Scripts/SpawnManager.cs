using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject[] enemyPrefabs;
    private float spawnRange = 9;

    // Start is called before the first frame update
    void Start()
    {
        // Spawn an enemy at a random position
        Vector3 randomPos = GenerateSpawnPosition();

        Instantiate(enemyPrefabs[0], randomPos, enemyPrefabs[0].transform.rotation);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // Generates a random position
    private Vector3 GenerateSpawnPosition()
    {
        float spawnPosX = Random.Range(-spawnRange, spawnRange);
        float spawnPosZ = Random.Range(-spawnRange, spawnRange);

        return new Vector3(spawnPosX, 0, spawnPosZ);
    }
}
