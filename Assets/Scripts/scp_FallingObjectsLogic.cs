using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scp_FallingObjectsLogic : MonoBehaviour
{
    //Referencing Gameobjects
    public GameObject[] spawners;
    public GameObject[] packages;
    private scp_GameManager gameMan;
    
    //Spawn Positions
    public  Vector2[] posArray;
    private Vector2 posA;
    private Vector2 posB;
    private Vector2 posC;
    private Vector2 posD;
    private Vector2 posE;
    //Timer Method Variables
    public float countdown = 3f;
    public float timer = 3f;
    public float timeBetweenPackages = 2f;
    //Deploy Method Variables
    private GameObject packageClone;
    public int packageRandomness;
    public int packageLocation;
    public bool hasBeenDeployed = false;
    public bool amIaGoodPackage = false;

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
        Countdown();
        AdaptiveDifficulty();
        countdown = Mathf.Clamp(countdown, 0, 10);
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

        gameMan = FindObjectOfType<scp_GameManager>();
        

        countdown = Mathf.Clamp(timer, 0, 10);
    }

    private void Countdown()
    {
        countdown -= Time.deltaTime;

        if (countdown <= 0)
        {
            DeployOrder();            
        }
    }

    private void DeployOrder()
    {
        packageLocation = Random.Range(0, 5);
        packageRandomness = Random.Range(0, 5);

        timer -= Time.deltaTime;

        

        if (timer <= 0)
        {
            DeployPackage();
            timer = 3f;
            
        }
        
    }

    private void DeployPackage()
    {    
       
        switch (packageRandomness)
        {
            case 0:
                Instantiate(packages[0], posArray[packageLocation], Quaternion.identity);
                amIaGoodPackage = true;
                break;
            case 1: Instantiate(packages[1], posArray[packageLocation], Quaternion.identity);
                amIaGoodPackage = false;
                break;
            case 2:
                Instantiate(packages[2], posArray[packageLocation], Quaternion.identity);
                amIaGoodPackage = false;
                break;
            case 3:
                Instantiate(packages[3], posArray[packageLocation], Quaternion.identity);
                amIaGoodPackage = true;
                break;
            case 4:
                Instantiate(packages[4], posArray[packageLocation], Quaternion.identity);
                amIaGoodPackage = true;
                break;            
        }

        hasBeenDeployed = true;
    }

    

    private void AdaptiveDifficulty()
    {
        if (gameMan.successRate < 3)
        {
            DeployCaseZero();
        }
        if (gameMan.successRate >= 6)
        {
            DeployCaseOne();
        }
        if (gameMan.successRate >= 9)
        {
            DeployCaseTwo();
        }
        if (gameMan.successRate >= 12)
        {
            DeployCaseThree();
        }
        if (gameMan.successRate >= 15)
        {
            DeployCaseFour();
        }


    }

    private void DeployCaseZero()
    {
        countdown -= Time.deltaTime;
        if (countdown <= 0)
        {
            timer -= Time.deltaTime;

            if (timer <= 0)
            {
                DeployPackage();
                timer = 3f;
            }
        }
    }
    private void DeployCaseOne()
    {
        countdown -= Time.deltaTime;
        if (countdown <= 0)
        {
            timer -= Time.deltaTime;

            if (timer <= 0)
            {
                DeployPackage();
                timer = 2f;
            }
        }
    }
    private void DeployCaseTwo()
    {
        countdown -= Time.deltaTime;
        if (countdown <= 0)
        {
            timer -= Time.deltaTime;

            if (timer <= 0)
            {
                DeployPackage();
                timer = 1f;
            }
        }
    }
    private void DeployCaseThree()
    {
        countdown -= Time.deltaTime;
        if (countdown <= 0)
        {
            timer -= Time.deltaTime;

            if (timer <= 0)
            {
                DeployPackage();
                timer = 0.5f;
            }
        }
    }
    private void DeployCaseFour()
    {
        countdown -= Time.deltaTime;
        if (countdown <= 0)
        {
            timer -= Time.deltaTime;

            if (timer <= 0)
            {
                DeployPackage();
                timer = 0.25f;
            }
        }
    }

}
