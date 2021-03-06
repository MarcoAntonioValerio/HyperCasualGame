﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scp_Ripple : MonoBehaviour
{
    private scp_VfxManager vfx;


    //Ripple Variables
    public Material RippleMaterial;
    public scp_Player player;
    public float MaxAmount = 50f;

    [Range(0, 1)]
    public float Friction = .9f;
    private float Amount = 0f;

    public Transform ripplePos;
    private Vector3 pos;
    private Camera cam;

    private void Start()
    {
        cam = GetComponent<Camera>();
        vfx = FindObjectOfType<scp_VfxManager>();
        pos = cam.WorldToScreenPoint(ripplePos.position);
        player = FindObjectOfType<scp_Player>();
    }
    void Update()
    {      

        pos = cam.WorldToScreenPoint(ripplePos.position);        

        this.RippleMaterial.SetFloat("_Amount", this.Amount);
        this.Amount *= this.Friction;
    }

    public void Ripple()
    {
        this.Amount = this.MaxAmount;

        this.RippleMaterial.SetFloat("_CenterX", pos.x);
        this.RippleMaterial.SetFloat("_CenterY", pos.y);
    }

    void OnRenderImage(RenderTexture src, RenderTexture dst)
    {
        Graphics.Blit(src, dst, this.RippleMaterial);
    }
}
