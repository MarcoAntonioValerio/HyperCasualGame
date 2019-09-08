﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scp_FallingObjectsLogic : MonoBehaviour
{
    //Referencing Gameobjects
    public GameObject[] spawners;
    public GameObject[] packages;
    
    //Spawn Positions
    public Vector2[] posArray;
    private Vector2 posA;
    private Vector2 posB;
    private Vector2 posC;
    private Vector2 posD;
    private Vector2 posE;
    //Spawner Method Variables
    public float timer = 20f;
    public int timeBetweenPackages = 2;
    private GameObject packageClone;
    public int packageRandomness;
    public int packageLocation;

    //TODO
    /* Find a way to spawn the packages at
     * an interval.*/

    void Start()
    {
        InitialisationParameters();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("space"))
        {
            DeployPackage();
        }
    }

    private void SpawnerLogic()
    {
        
    }



    private void InitialisationParameters()
    {

        posA = spawners[0].transform.position;
        posB = spawners[1].transform.position;
        posC = spawners[2].transform.position;
        posD = spawners[3].transform.position;
        posE = spawners[4].transform.position;

        posArray[0] = posA;
        posArray[1] = posB;
        posArray[2] = posC;
        posArray[3] = posD;
        posArray[4] = posE; 
    }

    private void DeployPackage()
    {
        packageRandomness   = Random.Range(0, 3);
        packageLocation     = Random.Range(0, 5);

        switch (packageRandomness)
        {
            case 0: Instantiate(packages[0], posArray[packageLocation], Quaternion.identity); break;
            case 1: Instantiate(packages[1], posArray[packageLocation], Quaternion.identity); break;
            case 2: Instantiate(packages[2], posArray[packageLocation], Quaternion.identity); break;
        }
    }

    
}