﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scp_Player : MonoBehaviour
{
    //Objects
    private scp_GameManager gameManager;
    private scp_FallingObjectsLogic fallingObjects;
    private scp_VfxManager vfx;
    private scp_Ripple ripple;
    
    //Variables
    public bool greenCollected = false;



    // Start is called before the first frame update
    void Start()
    {
        Initialisation();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Destroy(collision.gameObject);
        
        if (collision.gameObject.tag == "GoodBox")
        {
            gameManager.score += gameManager.packageValues[0];
            gameManager.successRate++;            
            vfx.GoodPickupParticles();
            vfx.addPointsPromptMethod();
            ripple.RippleEffect();
            greenCollected = true;
        }
        else if (collision.gameObject.tag == "BadBox")
        {
            gameManager.score += gameManager.packageValues[1];
            gameManager.successRate--;
            vfx.CamShake();
            vfx.BadPickupParticles();
            vfx.subtractPointsPromptMethod();
        }
         
        
    }

    private void Initialisation()
    {
        gameManager     = FindObjectOfType<scp_GameManager>();
        fallingObjects  = FindObjectOfType<scp_FallingObjectsLogic>();
        vfx             = FindObjectOfType<scp_VfxManager>();
        ripple          = FindObjectOfType<scp_Ripple>();
    }
}
