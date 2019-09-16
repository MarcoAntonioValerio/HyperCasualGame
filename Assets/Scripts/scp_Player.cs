using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scp_Player : MonoBehaviour
{
    //Objects
    private scp_GameManager gameManager;
    private scp_FallingObjectsLogic fallingObjects;
    //Variables
    



    // Start is called before the first frame update
    void Start()
    {
        Initialisation();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Destroy(collision.gameObject);
        switch (fallingObjects.packageRandomness)
        {
            case 0: gameManager.score += gameManager.packageValues[0]; break;
            case 1: gameManager.score += gameManager.packageValues[1]; break;
            case 2: gameManager.score += gameManager.packageValues[2]; break;
            case 3: gameManager.score += gameManager.packageValues[3]; break;
            case 4: gameManager.score += gameManager.packageValues[4]; break;
            case 5: gameManager.score += gameManager.packageValues[5]; break;
        }
    }

    private void Initialisation()
    {
        gameManager     = FindObjectOfType<scp_GameManager>();
        fallingObjects  = FindObjectOfType<scp_FallingObjectsLogic>();
    }
}
