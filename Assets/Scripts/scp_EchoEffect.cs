using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scp_EchoEffect : MonoBehaviour
{
    private float timeBtwSpawns;
    public float startTimeBtwSpawns;

    public GameObject echo;
    public scp_Dash dash;
    [SerializeField] float instanceLife = 2f;
    public scp_FallingObjectsLogic fallen;

       

    // Update is called once per frame
    void Update()
    {
        if (dash != null) { GhostTrailPlayer(); }
        PickupTrail();

    }

    

    private void GhostTrailPlayer()
    {        
        
       if (dash.direction != 0)
       {
              if (timeBtwSpawns <= 0)
              {
                    GameObject instance = (GameObject)Instantiate(echo, transform.position, Quaternion.identity);
                    Destroy(instance, instanceLife);
                    timeBtwSpawns = startTimeBtwSpawns;
              }
              else
              {
                    timeBtwSpawns -= Time.deltaTime;
              }
       }       
        
        
    }
    private void PickupTrail()
    {
        if (tag == "BadBox" || tag == "GoodBox")
        {
            if (timeBtwSpawns <= 0)
            {
                GameObject instance = (GameObject)Instantiate(echo, transform.position, Quaternion.identity);
                Destroy(instance, instanceLife);
                timeBtwSpawns = startTimeBtwSpawns;
            }
            else
            {
                timeBtwSpawns -= Time.deltaTime;
            }
        }
    }

    
}
