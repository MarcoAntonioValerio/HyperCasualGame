using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class scp_Scenemanager : MonoBehaviour
{
    public scp_GameManager gameMan;
    public Animator transitionAnim;
    public string sceneName;
    // Start is called before the first frame update
    void Start()
    {        
        FindGameManager();
    }

    private void Update()
    {

        if (SceneManager.GetActiveScene().name == "scn_MainMenu")
        {
            StartCoroutine(WaitAndLoadNewScene());
        }
        if (gameMan != null)
        {
            StartCoroutine(GameOverWhenTimeRunsOut());
        }
        
        
    }

    private void FindGameManager()
    {
        gameMan = FindObjectOfType<scp_GameManager>();
    }

    

    IEnumerator WaitAndLoadNewScene()
    {
        if (Input.anyKey)
        {
            transitionAnim.SetTrigger("end");
            yield return new WaitForSeconds(1.5f);
            SceneManager.LoadScene(sceneName);
        }
        
        
    }

    IEnumerator GameOverWhenTimeRunsOut()
    {
        if (gameMan.timeLeft <= 0)
        {
            transitionAnim.SetTrigger("end");
            yield return new WaitForSeconds(1.5f);
            SceneManager.LoadScene(sceneName);
        }
            
    }
    
}
