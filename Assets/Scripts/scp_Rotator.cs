using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scp_Rotator : MonoBehaviour
    
{
    public float rotationSpeed;
    

    // Update is called once per frame
    void Update()
    {
        Rotation();
    }

    private void Rotation()
    {
        transform.Rotate(0, 0, rotationSpeed);
    }
}
