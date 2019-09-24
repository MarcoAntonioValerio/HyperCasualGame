using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class scp_Scenemanager : MonoBehaviour
{
    public scp_GameManager gameMan;
    // Start is called before the first frame update
    void Start()
    {        
        FindGameManager();
    }

    private void Update()
    {
        LoadTheFirstLevel();
        GameOverWhenTimeRunsOut();
        
    }

    private void FindGameManager()
    {
        gameMan = FindObjectOfType<scp_GameManager>();
    }

    public void LoadTheFirstLevel()
    {
        if (SceneManager.GetActiveScene().name == "scn_MainMenu")
        {
            if (Input.anyKey)
            {
                SceneManager.LoadScene("scn_Level1");
            }
        }
    }

    public void GameOverWhenTimeRunsOut()
    {
        if (gameMan != null)
        {
            if (gameMan.timeLeft <= 0)
            {
                SceneManager.LoadScene("scn_GameOver");
            }
        }        
    }
    
}
