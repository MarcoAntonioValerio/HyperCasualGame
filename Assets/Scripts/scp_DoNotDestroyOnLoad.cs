﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scp_DoNotDestroyOnLoad : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        SetupSingleton(); 
    }

    private void SetupSingleton()
    {
        if (FindObjectsOfType(GetType()).Length > 1)
        {
            Destroy(gameObject);
        }
        else
        {
            DontDestroyOnLoad(gameObject);
        }

    }
    // Update is called once per frame
    void Update()
    {
        
    }
}