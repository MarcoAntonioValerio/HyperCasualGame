using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Kino;

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
    [Header("GlitchEffect")]
    public DigitalGlitch glitch;
    public scp_GameManager gameManager;
    public float glitchEnd          = 0.95f;
    public float glitchStageFour    = 0.16f;
    public float glitchStageThree   = 0.12f;
    public float glitchStageTwo     = 0.08f;
    public float glitchStageOne     = 0.04f;
    public float glitchZero         = 0f;

    private void Awake()
    {
        gameManager = FindObjectOfType<scp_GameManager>();
                  
        if (SceneManager.GetActiveScene().name == "scn_GameOver")
        {
            GameOverSceneEffects();
        }
    }
    private void Update()
    {
        if (SceneManager.GetActiveScene().name == "scn_Level1")
        {
            glitchWhenFailing();
        }         
    }
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
    public void glitchWhenFailing()
    {  
        switch (gameManager.lives)
        {
            case 5: glitch.intensity = glitchZero; break;
            case 4: glitch.intensity = Mathf.Lerp(glitchZero, glitchStageOne, 1f); break;
            case 3: glitch.intensity = Mathf.Lerp(glitchStageOne, glitchStageTwo, 1f); break;
            case 2: glitch.intensity = Mathf.Lerp(glitchStageTwo, glitchStageThree, 1f); break;
            case 1: glitch.intensity = Mathf.Lerp(glitchStageThree, glitchStageFour, 1f); break;
            case 0: glitch.intensity = Mathf.Lerp(glitchStageFour, glitchEnd, 0.2f); break;
        }
    }

    private void GameOverSceneEffects()
    {
        glitch.intensity = glitchEnd;
        StartCoroutine(WaitThenReduceGlitch());
        
    }

    IEnumerator WaitThenReduceGlitch()
    {
        yield return new WaitForSeconds(2);
        glitch.intensity = Mathf.Lerp(glitchEnd, glitchStageOne, 5f);

    }
}
