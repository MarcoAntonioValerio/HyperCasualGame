using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scp_Movement : MonoBehaviour
{
    //Referencing
    private Rigidbody2D rigid2d;

    //Variables
    [Header("Movement Values")]
    public float runSpeed = 40f;
    float horizontalMove = 0f;
    [SerializeField] private int rightVelocity  =  2;
    [SerializeField] private int leftVelocity   = -2;
    

    void Start()
    {
        InitialisationValues();
    }    

    // Update is called once per frame
    void Update()
    {
       
    }

    private void FixedUpdate()
    {
        CharacterController();
    }

    private void CharacterController()
    {       
        var axisConfig = Input.GetAxisRaw("Horizontal");
        switch (axisConfig)
        {
            case -1: rigid2d.velocity = new Vector2(leftVelocity, 0);   break;
            case 0:  rigid2d.velocity = new Vector2(0, 0);              break;
            case  1: rigid2d.velocity = new Vector2(rightVelocity, 0);  break;

        }
    }

    

    private void InitialisationValues()
    {
        rigid2d = GetComponent<Rigidbody2D>();
        rigid2d.freezeRotation = true;
    }   


}
