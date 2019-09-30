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
    private Text gameOverScore;
    private Text gameOverScoreComment;



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
        FinalScore();
        FinalComment();
    }

    public void ScoreAndTimerUpdater()
    {
        scoreTextBox.text   = "SCORE:" + gameManager.score.ToString();
        timerTextBox.text = "LIVES: " + gameManager.lives.ToString("f0");
    }

    private void ChangeTimerColor()
    {
        if (gameManager.lives < 2)
        {
            timerTextBox.color = new Color(1,0,0);
        }
    }

    private void FinalScore()
    {
        gameOverScore.text = "THE TOTAL SCORE IS " + gameManager.score;
    }

    private void FinalComment()
    {
        if (gameManager.score < 2000)
        {
            gameOverScoreComment.text = "HUMAN, TRY AGAIN - RESTART SESSION" + gameManager.score;
        }
        else if (gameManager.score >= 2000 && gameManager.score < 5000)
        {
            gameOverScoreComment.text = "LOW SKILL DETECTED - RESTART SESSION" + gameManager.score;
        }
        else if (gameManager.score >= 5000 && gameManager.score < 10000)
        {
            gameOverScoreComment.text = "MINIMUM TARGET ACHIEVED - RESTART SESSION" + gameManager.score;
        }
        else if (gameManager.score >= 5000 && gameManager.score < 10000)
        {
            gameOverScoreComment.text = "MINIMUM TARGET ACHIEVED - RESTART SESSION" + gameManager.score;
        }
        else if (gameManager.score >= 10000 && gameManager.score < 30000)
        {
            gameOverScoreComment.text = "ASCENSION LEVEL - RESTART SESSION" + gameManager.score;
        }
        else if (gameManager.score >= 30000 && gameManager.score < 60000)
        {
            gameOverScoreComment.text = "GODLIKE - RESTART SESSION" + gameManager.score;
        }
        else if (gameManager.score >= 60000 && gameManager.score < 100000)
        {
            gameOverScoreComment.text = "01001101011 - RESTART SESSION" + gameManager.score;
        }
        else if (gameManager.score >= 100000 && gameManager.score < 200000)
        {
            gameOverScoreComment.text = "GOOD JOB, I TIP MY HAT TO YOU - RESTART SESSION" + gameManager.score;
        }
    }


   

    private void Initialisation()
    {
        packages = FindObjectOfType<scp_FallingObjectsLogic>();
        gameManager = FindObjectOfType<scp_GameManager>();

        scoreTextBox        = GameObject.Find("txtPro_Score").GetComponent<TextMeshProUGUI>();
        scoreTextBox.text   = "SCORE:" + gameManager.score.ToString();

        timerTextBox = GameObject.Find("txtPro_Timer").GetComponent<TextMeshProUGUI>();
        timerTextBox.text = "LIVES: " + gameManager.lives.ToString("f0");

        gameOverScore = GameObject.Find("txt_TotalScore").GetComponent<Text>();
        

        gameOverScoreComment = GameObject.Find("txt_TotalScoreComment").GetComponent<Text>();

    }
}
