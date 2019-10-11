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
    private scp_AudioManager audioManager;
    //LerpStuff
    public Transform[] lerpPositionArray;
    private float lerpTime = 0.2f;
    //[SerializeField]private float percentage = 1f;
    private Vector3 newPosition;
    //[SerializeField] private float timeDivider = 2f;
    private int arrayNumber = 2;
    public bool waiting;
    
    
    [SerializeField]float timePercentage = 0f;


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
        Debug.Log("We are at array position number " + arrayNumber);
        

        Dash();
    }

    private void Clamper()
    {
        if (arrayNumber <= 0) { arrayNumber = 0; }
        if (arrayNumber >= 4) { arrayNumber = 4; }
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
            if (!waiting)
            {
                if (Input.GetKeyDown(KeyCode.RightArrow))
                {
                    StartCoroutine(MoveToNextPositionToTheRight());
                    direction = 2;
                    anim.SetBool("isDashing", true);
                    audioManager.Dash();
                }
                else if (Input.GetKeyDown(KeyCode.LeftArrow))
                {
                    StartCoroutine(MoveToNextPositionToTheLeft());
                    direction = 1;
                    anim.SetBool("isDashing", true);
                    audioManager.Dash();
                }
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

    

    private IEnumerator MoveToNextPositionToTheLeft()
    {
        waiting = true;
        float timePercentage = 0f;
        Vector3 startPos = transform.position;
        arrayNumber--;
        Clamper();
        while (timePercentage < 1)
        {
            timePercentage += Time.deltaTime / lerpTime;            
            transform.position = Vector3.Lerp(startPos, lerpPositionArray[arrayNumber].transform.position, timePercentage);
            yield return null;
            
        }
        waiting = false;
    }
    private IEnumerator MoveToNextPositionToTheRight()
    {
        waiting = true;
        float timePercentage = 0f;
        Vector3 startPos = transform.position;
        arrayNumber++;
        Clamper();
        while (timePercentage < 1)
        {
            timePercentage += Time.deltaTime / lerpTime;
            transform.position = Vector3.Lerp(startPos, lerpPositionArray[arrayNumber].transform.position, timePercentage);
            yield return null;
            
            
        }
        waiting = false;
    }
    
}
