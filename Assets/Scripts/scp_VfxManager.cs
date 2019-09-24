using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class scp_VfxManager : MonoBehaviour
{
    
    [Header("ScreenShake")]
    public Animator camAnim;
    [Header("Particles")]
    public GameObject goodPickupParticles;
    public GameObject badPickupParticles;
    public Transform particleSpawnerPos;
    [Header("PlayerFeedback")]    
    public GameObject subtractPointsPrompt;
    public GameObject addPointsPrompt;    
    public Transform subtractPointsPromptPosition;
    public Transform addPointsPromptPosition;
    

    public void CamShake()
    {
        camAnim.SetTrigger("shake");
    }
    public void GoodPickupParticles()
    {
        var goodExplosion = Instantiate(goodPickupParticles, particleSpawnerPos.position, Quaternion.identity) as GameObject;
        Destroy(goodExplosion, 0.8f);
    }
    public void BadPickupParticles()
    {
        var badExplosion = Instantiate(badPickupParticles, particleSpawnerPos.position, Quaternion.identity) as GameObject;
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
        var subtractPoints = Instantiate(this.subtractPointsPrompt, subtractPointsPromptPosition.position, Quaternion.identity) as GameObject;
        subtractPoints.transform.SetParent(GameObject.FindGameObjectWithTag("Canvas").transform, false);
        subtractPoints.transform.position = subtractPointsPromptPosition.position;
        Destroy(subtractPoints, 0.8f);
    }
    

}
