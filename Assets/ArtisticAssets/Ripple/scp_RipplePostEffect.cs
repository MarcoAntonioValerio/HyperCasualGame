using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scp_RipplePostEffect : MonoBehaviour
{
    //public GameObject player;
    public Material RippleMaterial;
    public float MaxAmount = 50f;
    public Vector3 pos;
    public GameObject RippleCenter;
    private Camera cam;
    private scp_Player player;


    [Range(0, 1)]
    public float Friction = .9f;

    private float Amount = 0f;

    private void Start()
    {
        cam = this.GetComponent<Camera>();
        player = FindObjectOfType<scp_Player>();
    }
    void Update()
    {
        if (cam != null)
        {
            if (player.greenCollected)
            {
                this.Amount = this.MaxAmount;
                this.RippleMaterial.SetFloat("_CenterX", pos.x);
                this.RippleMaterial.SetFloat("_CenterY", pos.y);
                Debug.Log("Effect Firing!");
                player.greenCollected = false;
            }
            this.RippleMaterial.SetFloat("_Amount", this.Amount);
            this.Amount *= this.Friction;
            pos = cam.WorldToScreenPoint(RippleCenter.transform.position);
            Debug.Log(pos);

            
        }    
        
    }

    void OnRenderImage(RenderTexture src, RenderTexture dst)
    {
        Graphics.Blit(src, dst, this.RippleMaterial);
    }

    public void RippleTriggerEffect()
    {        
        
    }


}
