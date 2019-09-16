using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scp_EchoEffect : MonoBehaviour
{
    private float timeBtwSpawns;
    public float startTimeBtwSpawns;

    public GameObject echo;
    private scp_Dash dash;
    [SerializeField] float instanceLife = 2f;

    // Start is called before the first frame update
    void Start()
    {
        Setup();
    }

    private void Setup()
    {
        dash = GetComponent<scp_Dash>();
    }

    // Update is called once per frame
    void Update()
    {
        if (dash.direction != 0)
        {
            if (timeBtwSpawns <= 0)
            {
                GameObject instance = (GameObject)Instantiate(echo, transform.position, Quaternion.identity);
                Destroy(instance, instanceLife);
                timeBtwSpawns = startTimeBtwSpawns;
            }
            else
            {
                timeBtwSpawns -= Time.deltaTime;
            }
        }
    }
}
