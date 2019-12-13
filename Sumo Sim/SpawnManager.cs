using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject enemyPrefab;
    public GameObject powerupPrefab;
    public float spawnRange=9.0f;
    public float enemyCount;
    public int waveNumber=1;
    // Start is called before the first frame update
    void Start()
    {
        SpawnEnemy(waveNumber);
    }

    // Update is called once per frame
    void Update()
    {

        enemyCount=FindObjectsOfType<Enemy>().Length;
        if(enemyCount == 0)
        {
            waveNumber++;
            SpawnEnemy(waveNumber);
            Instantiate(powerupPrefab,GenerateSpawnPosition(),powerupPrefab.transform.rotation);
        }
    }
    void SpawnEnemy(int enemiesToSpawn)
    {
        for(int i=0;i<enemiesToSpawn;i++)
        {
            Instantiate(enemyPrefab,GenerateSpawnPosition(),enemyPrefab.transform.rotation);
        }
    }
    private Vector3 GenerateSpawnPosition()
    {
      float randomSpawnX=Random.Range(-spawnRange,spawnRange);
      float randomSpawnZ=Random.Range(-spawnRange,spawnRange);

      Vector3 spawnPosition=new Vector3(randomSpawnX,0,randomSpawnZ);
      return spawnPosition;
    }
}
