using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class scp_GameManager : MonoBehaviour
{
    //Variables
    public int score;
    public float timeLeft = 60f;
    public int[] packageValues;
    public int successRate;
    

    private void Awake()
    {
        Initialisation();
    }
    // Start is called before the first frame update
    void Start()
    {
        SetupSingleton();
    }

    // Update is called once per frame
    void Update()
    {
        ValuesClamping();
        TimeGoingDown();
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

    private void Initialisation()
    {
        score = 0;
        successRate = 0;
    }

    private void TimeGoingDown()
    {
        if (SceneManager.GetActiveScene().name == ("scn_MainMenu"))
        {
            return;
        }
        else if (SceneManager.GetActiveScene().name == ("scn_GameOver"))
        {
            return;
        }
        else
        {
            timeLeft -= Time.deltaTime;
        }
              
    }

    private void ValuesClamping()
    {
        score = Mathf.Clamp(score, 0, 100000);
        successRate = Mathf.Clamp(successRate, 0, 100);
        timeLeft = Mathf.Clamp(timeLeft, 0, 120);
        
    }
}
