using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scp_Player : MonoBehaviour
{
    //Objects
    private scp_GameManager gameManager;
    private scp_FallingObjectsLogic fallingObjects;
    private scp_VfxManager vfx;
    private scp_Ripple ripple;
    public  scp_UIManager ui;
    public  scp_AudioManager audioObject;
    
    //Variables
    public bool greenCollected = false;



    // Start is called before the first frame update
    void Start()
    {
        Initialisation();
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        Destroy(collision.gameObject);

        if (collision.gameObject.tag == "GoodBox")
        {
            gameManager.score += gameManager.packageValues[0];
            gameManager.successRate++;
            vfx.GoodPickupParticles();
            vfx.addPointsPromptMethod();
            ripple.Ripple();
            audioObject.GoodPickupSound();
            
            greenCollected = true;
        }
        else if (collision.gameObject.tag == "BadBox")
        {
            if (gameManager.score >= 543)
            {
                gameManager.score += gameManager.packageValues[1];
            }
            else
            {
                gameManager.score = 0;
            }
            gameManager.successRate -= 3;
            gameManager.lives--;
            vfx.CamShake();
            vfx.BadPickupParticles();
            vfx.subtractPointsPromptMethod();
            ui.MinusOneLifeFeedback();
            audioObject.BadPickupSound();
            
        }

        else if (collision.gameObject.tag == "LifeBox")
        {
            gameManager.lives++;
            ripple.Ripple();
            ui.PlusOneLifeFeedback();
            audioObject.LifePickupSound();
        }
    }

    private void Initialisation()
    {
        gameManager     = FindObjectOfType<scp_GameManager>();
        fallingObjects  = FindObjectOfType<scp_FallingObjectsLogic>();
        vfx             = FindObjectOfType<scp_VfxManager>();
        ripple          = FindObjectOfType<scp_Ripple>();
        ui              = FindObjectOfType<scp_UIManager>();
        audioObject     = GameObject.Find("Pickups").GetComponent<scp_AudioManager>();
    }
}
