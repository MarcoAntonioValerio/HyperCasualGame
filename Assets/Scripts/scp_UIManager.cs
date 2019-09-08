using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class scp_UIManager : MonoBehaviour
{
    public Text countdownText;
    public Text timerText;
    public scp_FallingObjectsLogic packages;

    private void Awake()
    {
        SetUp();
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }    

    // Update is called once per frame
    void Update()
    {
        countdownText.text = packages.countdown.ToString();
        timerText.text = packages.timer.ToString();

    }

    private void SetUp()
    {
        countdownText   = GameObject.Find("txt_CountdownText").GetComponent<Text>();
        timerText       = GameObject.Find("txt_TimerText").GetComponent<Text>();
        packages = FindObjectOfType<scp_FallingObjectsLogic>();
    }
}
