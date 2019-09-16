using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scp_Dash : MonoBehaviour
{
    private Rigidbody2D rb;
    public float dashSpeed;
    private float dashTime;
    public float startDashTime;
    public int direction;
    
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
        rb = GetComponent<Rigidbody2D>();
        rb.gravityScale = 0;
        anim = GetComponent<Animator>();        
    }    
    

    private void Dash()
    {
        if (direction == 0)
        {
            anim.SetBool("isDashing", false);

            if (Input.GetKeyDown(KeyCode.RightArrow))
            {
                rb.velocity = Vector2.right * dashSpeed;
                direction = 2;               
                anim.SetBool("isDashing", true);
                
            }
            else if (Input.GetKeyDown(KeyCode.LeftArrow))
            {
                rb.velocity = Vector2.left * dashSpeed;
                direction = 1;                
                anim.SetBool("isDashing", true);      

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
}
