using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scp_VfxManager : MonoBehaviour
{
    
    
    public Animator camAnim;

    public void CamShake()
    {
        camAnim.SetTrigger("shake");
    }

    
}
