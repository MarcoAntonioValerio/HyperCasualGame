using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class scp_UIManager : MonoBehaviour
{
    public Text countdownText;
    public Text timerText;
    public TextMeshProUGUI scoreTextBox;
    public string testString = "Test String";

    private scp_FallingObjectsLogic packages;
    private scp_GameManager gameManager;

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
        scoreTextBox.text   = "Score:" + gameManager.score.ToString(); ; ;
    }

    private void TestingStuff()
    {
        countdownText.text  = packages.countdown.ToString();
        timerText.text      = packages.timer.ToString();
    }

    private void Initialisation()
    {
        countdownText       = GameObject.Find("txt_CountdownText").GetComponent<Text>();
        timerText           = GameObject.Find("txt_TimerText").GetComponent<Text>();
        scoreTextBox        = GameObject.Find("txtPro_Score").GetComponent<TextMeshProUGUI>();
        
        scoreTextBox.text   = "Score:" + gameManager.score.ToString(); 

        packages            = FindObjectOfType<scp_FallingObjectsLogic>();
        gameManager         = FindObjectOfType<scp_GameManager>();
    }
}
