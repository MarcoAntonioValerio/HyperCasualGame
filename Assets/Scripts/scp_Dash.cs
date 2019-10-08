using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scp_Dash : MonoBehaviour
{
    private Rigidbody2D rb;
    public float dashSpeed;
    private float dashTime;
    public float lerpTime = 2f;
    public float startDashTime;
    public int direction;
    private scp_AudioManager audioManager;

    public Transform[] lerpPositionArray;
    private Vector3 newPosition;
    
    //Dash Particles Variables
    //public ParticleSystem dashParticlesLeft;
    //public ParticleSystem dashParticlesRight;
    //Animation Variables
    private Animator anim;

    void Awake()
    {
        SetupVariables();
    }

    void Update()
    {
        
        Dash();
    }
    private void SetupVariables()
    {
        this.transform.position = lerpPositionArray[2].transform.position;
        newPosition = this.transform.position;
        rb = GetComponent<Rigidbody2D>();
        rb.gravityScale = 0;
        anim = GetComponent<Animator>();
        audioManager = GameObject.Find("Dash").GetComponent<scp_AudioManager>();
    }    
    

    private void Dash()
    {
        if (direction == 0)
        {
            anim.SetBool("isDashing", false);

            if (Input.GetKeyDown(KeyCode.RightArrow))
            {
                LerpingPositionsRight();
                direction = 2;               
                anim.SetBool("isDashing", true);
                audioManager.Dash();
                
            }
            else if (Input.GetKeyDown(KeyCode.LeftArrow))
            {
                LerpingPositionsLeft();
                direction = 1;                
                anim.SetBool("isDashing", true);
                audioManager.Dash();

            }
        }
        else
        {
            if (dashTime <= 0)
            {
                direction = 0;
                dashTime = startDashTime;
                rb.velocity = Vector2.zero;
            }
            else
            {
                dashTime -= Time.deltaTime;
            }
        }
    }

    void LerpingPositionsLeft()
    {
        //Debug.Log("Lerping Fired!");
        if (newPosition == lerpPositionArray[4].transform.position)
        {
            newPosition = lerpPositionArray[3].transform.position;
            transform.position = Vector3.Lerp(transform.position, newPosition, Time.deltaTime * lerpTime) ;

        }
        else if (newPosition == lerpPositionArray[3].transform.position)
        {
            newPosition = lerpPositionArray[2].transform.position;
            transform.position = Vector3.Lerp(transform.position, newPosition, Time.deltaTime * lerpTime);

        }
        else if (newPosition == lerpPositionArray[2].transform.position)
        {
            newPosition = lerpPositionArray[1].transform.position;
            transform.position = Vector3.Lerp(transform.position, newPosition, Time.deltaTime * lerpTime);

        }
        else if (newPosition == lerpPositionArray[1].transform.position)
        {
            newPosition = lerpPositionArray[0].transform.position;
            transform.position = Vector3.Lerp(transform.position, newPosition, Time.deltaTime * lerpTime);

        }
    }
    void LerpingPositionsRight()
    {
        Debug.Log("Lerping Fired!");
        if (newPosition == lerpPositionArray[0].transform.position)
        {
            newPosition = lerpPositionArray[1].transform.position;
            transform.position = Vector3.Lerp(transform.position, newPosition, Time.deltaTime * lerpTime);

        }
        else if (newPosition == lerpPositionArray[1].transform.position)
        {
            newPosition = lerpPositionArray[2].transform.position;
            transform.position = Vector3.Lerp(transform.position, newPosition, Time.deltaTime * lerpTime);

        }
        else if (newPosition == lerpPositionArray[2].transform.position)
        {
            newPosition = lerpPositionArray[3].transform.position;
            transform.position = Vector3.Lerp(transform.position, newPosition, Time.deltaTime * lerpTime);

        }
        else if (newPosition == lerpPositionArray[3].transform.position)
        {
            newPosition = lerpPositionArray[4].transform.position;
            transform.position = Vector3.Lerp(transform.position, newPosition, Time.deltaTime * lerpTime);

        }
    }
}
