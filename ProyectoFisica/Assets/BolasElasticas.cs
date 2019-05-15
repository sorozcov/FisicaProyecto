using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BolasElasticas : MonoBehaviour
   
{
    private Rigidbody rb;
    public float force = 20;
    int dir=0;

    public int direc;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        if (rb)
        {
            if (dir==1) {
                force = force * -1;
            }
            rb.AddForce(force, 0, 0, ForceMode.Impulse);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
