using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scp_AudioManager : MonoBehaviour
{
    public AudioClip backgroundMusic;
    public AudioClip goodPickupSound;
    public AudioClip badPickupSound;
    public AudioClip dashSound;
    public AudioSource audioManager;
   
    // Start is called before the first frame update
    void Start()
    {
        
        audioManager = GetComponent<AudioSource>();

        if (backgroundMusic != null)
        {
            audioManager.volume = 0f;

        }
        BackgroungMusic();


    }

    // Update is called once per frame
    void Update()
    {
        if (backgroundMusic != null)
        {
            audioManager.volume += 0.1f * Time.deltaTime;
            if (audioManager.volume >= 0.2f)
            {
                audioManager.volume = 0.2f;
            }
        }
    }
    

    public void GoodPickupSound()
    {
        audioManager.clip = goodPickupSound;
        audioManager.pitch = Random.Range(0.9f, 1.1f);
        audioManager.PlayOneShot(goodPickupSound);
        audioManager.volume = 1f;
    }
    public void BadPickupSound()
    {
        audioManager.clip = badPickupSound;
        audioManager.pitch = Random.Range(0.9f, 1.1f);
        audioManager.PlayOneShot(badPickupSound);
        audioManager.volume = 0.4f;
    }
    public void BackgroungMusic()
    {        
        audioManager.clip = backgroundMusic;        
        audioManager.Play();
        audioManager.loop = true;
    }
    public void Dash()
    {
        audioManager.clip = dashSound;
        audioManager.pitch = Random.Range(0.9f, 1.1f);
        audioManager.PlayOneShot(dashSound);
        audioManager.volume = 0.4f;
    }
}
