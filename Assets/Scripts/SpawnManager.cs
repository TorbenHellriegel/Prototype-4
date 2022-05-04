using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject[] enemyPrefabs;
    public GameObject[] powerupPrefabs;
    private float spawnRange = 9;
    private int enemyCount;
    private int waveNumber;

    // Start is called before the first frame update
    void Start()
    {
        waveNumber = 1;
        Instantiate(enemyPrefabs[0],  GenerateSpawnPosition(), Random.rotation);
        SpawnPowerup();
    }

    // Update is called once per frame
    void Update()
    {
        // Count enemys
        enemyCount = FindObjectsOfType<Enemy>().Length;

        // If there are no more enemys start a new wave
        if(enemyCount == 0)
        {
            waveNumber++;
            SpawnEnemyWave(waveNumber);
            SpawnPowerup();
        }
    }

    // Spawns a certain amount of enemys
    private void SpawnEnemyWave(int numOfEnemys)
    {
        //int[] enemyIndecies = GetWaveComposition(numOfEnemys);
        for(int i = 0; i < numOfEnemys; i++)
        {
            // Spawn arandom enemy at a random position
            int enemyIndex = Random.Range(0, Mathf.Min(enemyPrefabs.Length, waveNumber - i));
            Instantiate(enemyPrefabs[enemyIndex],  GenerateSpawnPosition(), Random.rotation);

            // Add the enemy difficulty to i to prevent spawning too many powerful enemys
            Enemy enemyScript = enemyPrefabs[enemyIndex].gameObject.GetComponent<Enemy>();
            i += enemyScript.enemyDifficulty - 1;
        }
    }

    // Spawns a random powerup
    private void SpawnPowerup()
    {
        int powerupIndex = Random.Range(0, powerupPrefabs.Length);
        Instantiate(powerupPrefabs[powerupIndex],  GenerateSpawnPosition(), powerupPrefabs[powerupIndex].transform.rotation);
    }

    // Generates a random position
    private Vector3 GenerateSpawnPosition()
    {
        float spawnPosX = Random.Range(-spawnRange, spawnRange);
        float spawnPosZ = Random.Range(-spawnRange, spawnRange);

        return new Vector3(spawnPosX, 0, spawnPosZ);
    }

    // Returns an index list of enemys which should be spawned
    private int[] GetWaveComposition(int numOfEnemys)
    {
        return null;
    }
}
