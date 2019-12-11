using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject[] animalPrefabs;
    private int xspawnrange=10;
    private int zspawn=20;
    private float startDelay=2;
    private float spawnInterval=1.5f;
    // Start is called before the first frame update
    void Start()
    {
     InvokeRepeating("SpawnRandomAnimal",startDelay,spawnInterval);
    }

    // Update is called once per frame
    void Update()
    {
      
    }
    void SpawnRandomAnimal()
    {
     int animalindex=Random.Range(0,animalPrefabs.Length);
     Vector3 spawnpos=new Vector3(Random.Range(-xspawnrange,xspawnrange),0,zspawn);
     Instantiate(animalPrefabs[animalindex],spawnpos,animalPrefabs[animalindex].transform.rotation);
    }
}
