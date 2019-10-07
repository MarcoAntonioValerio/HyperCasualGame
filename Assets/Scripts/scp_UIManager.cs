using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class scp_UIManager : MonoBehaviour
{
    //Objects
    public  Text countdownText;    
    private scp_FallingObjectsLogic packages;
    private scp_GameManager gameManager;
    public  TextMeshProUGUI scoreTextBox;
    public  TextMeshProUGUI timerTextBox;
    public  GameObject minusOneLifePosition;
    public  GameObject minusOneLife;
    public  GameObject plusOneLife;
    //Variables
    public string testString = "Test String";
    private Text gameOverScore;
    private Text gameOverScoreComment;



    private void Awake()
    {
        Initialisation();
    }
    
    
    
    void Update()
    {        
        ScoreAndTimerUpdater();
        ChangeTimerColor();               
    }

    private void OnEnable()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    public void OnSceneLoaded(Scene scene, LoadSceneMode mode)    
    {
        
        GameOverInitialisation();
    }

    public void ScoreAndTimerUpdater()
    {

        if (scoreTextBox != null)
        {
            scoreTextBox.text = "SCORE:" + gameManager.score.ToString();
        }
        if (timerTextBox != null)
        {
            timerTextBox.text = "LIVES: " + gameManager.lives.ToString("f0");
        }
            
    }

    private void ChangeTimerColor()
    {
        if (timerTextBox != null)
        {
            if (gameManager.lives < 2)
            {
                timerTextBox.color = new Color(1, 0, 0);
            }
        }
        
    }


    private void FinalComment()
    {
        if (gameOverScoreComment != null)
        {
            if (gameManager.score < 2000)
            {
                gameOverScoreComment.text = "HUMAN, TRY AGAIN - RESTART SESSION";
            }
            else if (gameManager.score >= 2000 && gameManager.score < 5000)
            {
                gameOverScoreComment.text = "LOW SKILL DETECTED - RESTART SESSION";
            }
            else if (gameManager.score >= 5000 && gameManager.score < 10000)
            {
                gameOverScoreComment.text = "MINIMUM TARGET ACHIEVED - RESTART SESSION";
            }
            else if (gameManager.score >= 5000 && gameManager.score < 10000)
            {
                gameOverScoreComment.text = "MINIMUM TARGET ACHIEVED - RESTART SESSION";
            }
            else if (gameManager.score >= 10000 && gameManager.score < 30000)
            {
                gameOverScoreComment.text = "ASCENSION LEVEL - RESTART SESSION";
            }
            else if (gameManager.score >= 30000 && gameManager.score < 60000)
            {
                gameOverScoreComment.text = "GODLIKE - RESTART SESSION";
            }
            else if (gameManager.score >= 60000 && gameManager.score < 100000)
            {
                gameOverScoreComment.text = "01001101011 - RESTART SESSION";
            }
            else if (gameManager.score >= 100000 && gameManager.score < 200000)
            {
                gameOverScoreComment.text = "GOOD JOB, I TIP MY HAT TO YOU - RESTART SESSION";
            }
            else if (gameManager.score >= 200000 && gameManager.score < 300000)
            {
                gameOverScoreComment.text = "Jesus - RESTART SESSION";
            }
            else if (gameManager.score >= 300000 && gameManager.score < 400000)
            {
                gameOverScoreComment.text = "SHOW THIS SCORE TO YOUR MOM - RESTART SESSION";
            }
            else if (gameManager.score >= 400000 && gameManager.score < 500000)
            {
                gameOverScoreComment.text = "YOU ARE A PROFESSIONAL NOW - RESTART SESSION";
            }
            else if (gameManager.score >= 500000 && gameManager.score < 600000)
            {
                gameOverScoreComment.text = "GOOD JOB, I TIP MY HAT TO YOU - RESTART SESSION";
            }
        }
            
    }

    public void MinusOneLifeFeedback()
    {
        var minusFeedback = Instantiate(minusOneLife, minusOneLifePosition.transform.position, Quaternion.identity) as GameObject;
        minusFeedback.transform.SetParent(GameObject.FindGameObjectWithTag("Canvas").transform, false);
        minusFeedback.transform.position = minusOneLifePosition.transform.position;
        Destroy(minusFeedback, 2f);

    }

    public void PlusOneLifeFeedback()
    {
        var plusFeedback = Instantiate(plusOneLife, minusOneLifePosition.transform.position, Quaternion.identity) as GameObject;
        plusFeedback.transform.SetParent(GameObject.FindGameObjectWithTag("Canvas").transform, false);
        plusFeedback.transform.position = minusOneLifePosition.transform.position;
        Destroy(plusFeedback, 2f);
    }
   

    private void Initialisation()
    {
        
        packages = FindObjectOfType<scp_FallingObjectsLogic>();
        gameManager = FindObjectOfType<scp_GameManager>();

        scoreTextBox        = GameObject.Find("txtPro_Score").GetComponent<TextMeshProUGUI>();
        scoreTextBox.text   = "SCORE:" + gameManager.score.ToString();

        timerTextBox = GameObject.Find("txtPro_Timer").GetComponent<TextMeshProUGUI>();
        timerTextBox.text = "LIVES: " + gameManager.lives.ToString("f0");



        

    }

    private void GameOverInitialisation()
    {
        gameOverScore = GameObject.Find("txt_TotalScore").GetComponent<Text>();        
        gameOverScore.text = "THE TOTAL SCORE IS " + gameManager.score + " AND YOU SURVIVED " + gameManager.playTime.ToString("f2") + " seconds!"; ;
        gameOverScoreComment = GameObject.Find("txt_TotalScoreComment").GetComponent<Text>();             
        FinalComment();
    }
}
