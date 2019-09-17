using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scp_GameManager : MonoBehaviour
{
    //Variables
    public int score;
    public int[] packageValues;
    public int successRate;

    private void Awake()
    {
        Initialisation();
    }
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        ValuesClamping();
    }

    private void Initialisation()
    {
        score = 0;
        successRate = 0;
    }

    private void ValuesClamping()
    {
        score = Mathf.Clamp(score, 0, 100000);
        successRate = Mathf.Clamp(successRate, 0, 100);
    }
}
