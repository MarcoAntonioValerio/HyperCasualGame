using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class scp_UIManager : MonoBehaviour
{
    //Objects
    public  Text countdownText;    
    private scp_FallingObjectsLogic packages;
    private scp_GameManager gameManager;
    public  TextMeshProUGUI scoreTextBox;
    public  TextMeshProUGUI timerTextBox;
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
        ScoreAndTimerUpdater();
        ChangeTimerColor();
    }

    public void ScoreAndTimerUpdater()
    {
        scoreTextBox.text   = "SCORE:" + gameManager.score.ToString();
        timerTextBox.text = gameManager.timeLeft.ToString("f0");
    }

    private void ChangeTimerColor()
    {
        if (gameManager.timeLeft <= 15)
        {
            timerTextBox.color = new Color(1,0,0);
        }
    }

   

    private void Initialisation()
    {
        packages = FindObjectOfType<scp_FallingObjectsLogic>();
        gameManager = FindObjectOfType<scp_GameManager>();

        scoreTextBox        = GameObject.Find("txtPro_Score").GetComponent<TextMeshProUGUI>();
        scoreTextBox.text   = "SCORE:" + gameManager.score.ToString();

        timerTextBox = GameObject.Find("txtPro_Timer").GetComponent<TextMeshProUGUI>();
        timerTextBox.text = gameManager.timeLeft.ToString("f0");
    }
}
