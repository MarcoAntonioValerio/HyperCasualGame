using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scp_GameManager : MonoBehaviour
{
    //Initial Values
    public int score;
    public int packageValue = 123;

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
