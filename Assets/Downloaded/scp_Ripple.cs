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


    private void Start()
    {
        vfx = FindObjectOfType<scp_VfxManager>();
    }

    //To sort Out
    /*
    public void RippleEffect()
    {

        RippleSetup();

        this.RippleMaterial.SetFloat("_Amount", this.Amount);
        this.Amount *= this.Friction;
    }

    private void RippleSetup()
    {
        this.Amount = this.MaxAmount;
        Vector3 pos = vfx.particleSpawnerPos.position;
        this.RippleMaterial.SetFloat("_CenterX", pos.x);
        this.RippleMaterial.SetFloat("_CenterY", pos.y);
    }*/

    void OnRenderImage(RenderTexture src, RenderTexture dst)
    {
        Graphics.Blit(src, dst, this.RippleMaterial);
    }
}
