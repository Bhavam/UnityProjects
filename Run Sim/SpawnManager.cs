﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject obstaclePrefab;
    private PlayerController playerControllerScript;
    private Vector3 spawnpos=new Vector3(30,0,0);
    private float startDelay=2;
    private float repeatRate=2;
    // Start is called before the first frame update
    void Start()
    {
        playerControllerScript=GameObject.Find("Player").GetComponent<PlayerController>();
        InvokeRepeating("spawnObstacle",startDelay,repeatRate);
    }

    // Update is called once per frame
    void Update()
    {
      
    }
    void spawnObstacle()
    {
        if(playerControllerScript.gameOver == false)
        {Instantiate(obstaclePrefab,spawnpos,obstaclePrefab.transform.rotation);}
    }
}
