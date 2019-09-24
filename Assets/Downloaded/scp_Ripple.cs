using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scp_Ripple : MonoBehaviour
{
    private scp_VfxManager vfx;


    //Ripple Variables
    public Material RippleMaterial;
    public float MaxAmount = 50f;

    [Range(0, 1)]
    public float Friction = .9f;
    private float Amount = 0f;

    public Transform ripplePos;


    private void Start()
    {
        vfx = FindObjectOfType<scp_VfxManager>();
    }
    void Update()
    {
        if (Input.GetMouseButton(0))
        {
            this.Amount = this.MaxAmount;
            Vector3 pos = ripplePos.position;
            this.RippleMaterial.SetFloat("_CenterX", pos.x);
            this.RippleMaterial.SetFloat("_CenterY", pos.y);
        }

        this.RippleMaterial.SetFloat("_Amount", this.Amount);
        this.Amount *= this.Friction;
    }

    void OnRenderImage(RenderTexture src, RenderTexture dst)
    {
        Graphics.Blit(src, dst, this.RippleMaterial);
    }
}
