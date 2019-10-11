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
    public  TextMeshProUGUI livesTextBox;
    public  Text            timeTextBox;
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
        if (livesTextBox != null)
        {
            livesTextBox.text = "LIVES: " + gameManager.lives.ToString("f0");
        }
        if (timeTextBox != null)
        {
            timeTextBox.text = "TIME: " + gameManager.playTime.ToString("f0");
        }

    }

    private void ChangeTimerColor()
    {
        if (livesTextBox != null)
        {
            if (gameManager.lives < 2)
            {
                livesTextBox.color = new Color(1, 0, 0);
            }
        }
        
    }


    private void FinalComment()
    {
        if (gameOverScoreComment != null)
        {
            if (gameManager.score < 20000)
            {
                gameOverScoreComment.text = "HUMAN, TRY AGAIN - RESTART SESSION";
            }
            else if (gameManager.score >= 20000 && gameManager.score < 50000)
            {
                gameOverScoreComment.text = "LOW SKILL DETECTED - RESTART SESSION";
            }
            else if (gameManager.score >= 50000 && gameManager.score < 100000)
            {
                gameOverScoreComment.text = "MINIMUM TARGET ACHIEVED - RESTART SESSION";
            }

            else if (gameManager.score >= 100000 && gameManager.score < 300000)
            {
                gameOverScoreComment.text = "ASCENSION LEVEL NOT ACHIEVED - RESTART SESSION";
            }
            else if (gameManager.score >= 300000 && gameManager.score < 600000)
            {
                gameOverScoreComment.text = "KEEP PLAYING PUNY HUMAN - RESTART SESSION";
            }
            else if (gameManager.score >= 600000 && gameManager.score < 1000000)
            {
                gameOverScoreComment.text = "NOT QUITE MY TEMPO - RESTART SESSION";
            }
            else if (gameManager.score >= 1000000 && gameManager.score < 2000000)
            {
                gameOverScoreComment.text = "ASCENSION LEVEL ACHIEVED, I WAS JOKING KEEP GOING  - RESTART SESSION";
            }
            else if (gameManager.score >= 2000000 && gameManager.score < 3000000)
            {
                gameOverScoreComment.text = "WELL DONE, HUMAN- RESTART SESSION";
            }
            else if (gameManager.score >= 3000000 && gameManager.score < 4000000)
            {
                gameOverScoreComment.text = "SHOW THIS SCORE TO YOUR MOM - RESTART SESSION";
            }
            else if (gameManager.score >= 4000000 && gameManager.score < 5000000)
            {
                gameOverScoreComment.text = "YOU ARE A PROFESSIONAL NOW - RESTART SESSION";
            }
            else if (gameManager.score >= 5000000 && gameManager.score < 6000000)
            {
                gameOverScoreComment.text = "CHALLENGE SOMEONE TO BEAT YOUR SCORE - RESTART SESSION";
            }
            else if (gameManager.score > 6000000)
            {
                gameOverScoreComment.text = "YOU HAVE ASCENDED, SEND ME YOUR SCORE HUMAN - TWITTER @iS_m4v - RESTART SESSION";
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

        livesTextBox = GameObject.Find("txtPro_Lives").GetComponent<TextMeshProUGUI>();
        livesTextBox.text = "LIVES: " + gameManager.lives.ToString("f0");

        timeTextBox = GameObject.Find("txt_Timer").GetComponent<Text>();      

    }

    private void GameOverInitialisation()
    {
        gameOverScore = GameObject.Find("txt_TotalScore").GetComponent<Text>();        
        gameOverScore.text = "THE TOTAL SCORE IS " + gameManager.score + " AND YOU SURVIVED " + gameManager.playTime.ToString("f2") + " seconds!"; ;
        gameOverScoreComment = GameObject.Find("txt_TotalScoreComment").GetComponent<Text>();             
        FinalComment();
    }
}
