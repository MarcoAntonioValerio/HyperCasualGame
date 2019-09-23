using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scp_VfxManager : MonoBehaviour
{
    
    
    public Animator camAnim;

    public GameObject goodPickup;
    public GameObject badPickup;
    public GameObject subtractPointsPrompt;
    public GameObject addPointsPrompt;

    public Transform particleSpawnerPos;
    public Transform subtractPointsPromptPosition;
    public Transform addPointsPromptPosition;

    

    

    



    public void CamShake()
    {
        camAnim.SetTrigger("shake");
    }

    public void GoodPickupParticles()
    {
        var goodExplosion = Instantiate(goodPickup, particleSpawnerPos.position, Quaternion.identity) as GameObject;
        Destroy(goodExplosion, 0.8f);
    }
    public void BadPickupParticles()
    {
        var badExplosion = Instantiate(badPickup, particleSpawnerPos.position, Quaternion.identity) as GameObject;
        Destroy(badExplosion, 0.8f);
    }
    public void addPointsPromptMethod()
    {
        var addPoints = Instantiate(addPointsPrompt, addPointsPromptPosition.position, Quaternion.identity) as GameObject;
        addPoints.transform.SetParent(GameObject.FindGameObjectWithTag("Canvas").transform, false);
        addPoints.transform.position = addPointsPromptPosition.position;
        Destroy(addPoints, 0.8f);
    }
    public void subtractPointsPromptMethod()
    {        
        var subtractPoints = Instantiate(subtractPointsPrompt, subtractPointsPromptPosition.position, Quaternion.identity) as GameObject;
        subtractPoints.transform.SetParent(GameObject.FindGameObjectWithTag("Canvas").transform, false);
        subtractPoints.transform.position = subtractPointsPromptPosition.position;
        Destroy(subtractPoints, 0.8f);
    }


}
