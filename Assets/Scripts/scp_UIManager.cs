using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class scp_UIManager : MonoBehaviour
{
    //Objects
    public  Text countdownText;
    public  Text timerText;
    private scp_FallingObjectsLogic packages;
    private scp_GameManager gameManager;
    public  TextMeshProUGUI scoreTextBox;
    //Variables
    public string testString = "Test String";

    

    private void Awake()
    {
        Initialisation();
    }
    
    void Start()
    {
        
    }    
    
    void Update()
    {
        ScoreUpdater();
    }

    public void ScoreUpdater()
    {
        scoreTextBox.text   = "Score:" + gameManager.score.ToString();
    }

    private void TestingStuff()
    {
        countdownText.text  = packages.countdown.ToString();
        timerText.text      = packages.timer.ToString();
    }

    private void Initialisation()
    {
        packages = FindObjectOfType<scp_FallingObjectsLogic>();
        gameManager = FindObjectOfType<scp_GameManager>();

        scoreTextBox        = GameObject.Find("txtPro_Score").GetComponent<TextMeshProUGUI>();
        scoreTextBox.text   = "Score:" + gameManager.score.ToString(); 

        
    }
}
