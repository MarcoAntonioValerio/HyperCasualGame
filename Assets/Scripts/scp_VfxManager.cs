using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scp_VfxManager : MonoBehaviour
{
    
    public ParticleSystem[] anticipationParticles;

    private scp_FallingObjectsLogic packages;

    // Start is called before the first frame update
    void Start()
    {
        packages = FindObjectOfType<scp_FallingObjectsLogic>(); 
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void EmitRightParticles()
    {

    }
}
