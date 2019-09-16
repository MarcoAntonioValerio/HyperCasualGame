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

    void Start()
    {
        SetupVariables();
    }

    private void SetupVariables()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.gravityScale = 0;
        anim = GetComponent<Animator>();
        
        
    }

    // Update is called once per frame
    void Update()
    {
        Dash();
    }

    private void Dash()
    {
        if (direction == 0)
        {
            anim.SetBool("isDashing", false);

            if (Input.GetKeyDown(KeyCode.RightArrow))
            {
                direction = 2;
                anim.SetBool("isDashing", true);
                
            }
            else if (Input.GetKeyDown(KeyCode.LeftArrow))
            {
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

                if (direction == 1) { rb.velocity = Vector2.left * dashSpeed; }
                else if (direction == 2) { rb.velocity = Vector2.right * dashSpeed; }
            }
        }
    }
}
