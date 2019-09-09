using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scp_GameManager : MonoBehaviour
{
    //Variables
    public int score;
    public int packageAValue = 123;
    public int packageBValue = 320;
    public int packageCValue = -100;

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
        
    }

    private void Initialisation()
    {
        score = 0;
    }
}
