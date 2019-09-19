using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class scp_Scenemanager : MonoBehaviour
{
    private scp_GameManager gameMan;
    // Start is called before the first frame update
    void Start()
    {
        SetupSingleton();
        SetupValues();
    }

    private void Update()
    {
        LoadTheFirstLevel();
        GameOverWhenTimeRunsOut();
    }

    private void SetupValues()
    {
        gameMan = FindObjectOfType<scp_GameManager>();
    }

    private void LoadTheFirstLevel()
    {
        if (SceneManager.GetActiveScene().name == "scn_MainMenu")
        {
            if (Input.anyKey)
            {
                SceneManager.LoadScene("scn_Level1");
            }
        }
    }

    private void GameOverWhenTimeRunsOut()
    {
        if (gameMan.timeLeft <= 0)
        {
            SceneManager.LoadScene("scn_GameOver");
        }
    }

    private void SetupSingleton()
    {
        if (FindObjectsOfType(GetType()).Length > 1)
        {
            Destroy(gameObject);
        }
        else
        {
            DontDestroyOnLoad(gameObject);
        }
    }
}
