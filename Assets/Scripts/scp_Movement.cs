﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scp_Movement : MonoBehaviour
{
    public float moveSpeed = 300f;
    public float leftSpeed = -1.0f;
    public float rightSpeed = 1.0f;

    public GameObject character;
    private Rigidbody2D characterBody;
    
    void Start()
    {
        InitialisationValues();
    }

    

    // Update is called once per frame
    void Update()
    {
        CharacterController();

    }

    private void CharacterController()
    {
        if (Input.GetKeyDown("right"))
        {
            //move right
            RunCharacter(rightSpeed);
        }
        if (Input.GetKeyDown("left"))
        {
            //move left
            RunCharacter(leftSpeed);
        }
    }

    private void InitialisationValues()
    {
        characterBody = character.GetComponent<Rigidbody2D>();
    }
    private void RunCharacter(float horizontalImput)
    {
        characterBody.AddForce(new Vector2(horizontalImput * moveSpeed * Time.deltaTime, 0));
    }


}