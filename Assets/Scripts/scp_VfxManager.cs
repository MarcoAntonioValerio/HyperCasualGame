using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scp_VfxManager : MonoBehaviour
{
    
    
    public Animator camAnim;
    public GameObject goodPickup;
    public GameObject badPickup;
    public Transform particleSpawnerPos;

    

    public void CamShake()
    {
        camAnim.SetTrigger("shake");
    }

    public void GoodPickupParticles()
    {
        var goodExplosion = Instantiate(goodPickup, particleSpawnerPos.position, Quaternion.identity) as GameObject;
        Destroy(goodExplosion, 0.8f);
    }
    public void BadPickupParticles()
    {
        var badExplosion = Instantiate(badPickup, particleSpawnerPos.position, Quaternion.identity) as GameObject;
        Destroy(badExplosion, 0.8f);
    }
}
