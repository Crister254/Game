using System;
using UnityEngine;

public class PlayercController : MonoBehaviour

{
    public float acceleration = 10f;
    public float turnSpeed = 100f;

    private Rigidbody rb;
    
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        
        if (Input.GetKey(KeyCode.W)){
            float Force = acceleration * Time.fixedDeltaTime;
            print(Force);
            rb.AddForce(transform.forward * Force, ForceMode.VelocityChange);
        }
    
       if (Input.GetKey(KeyCode.S)){
            float Force = -(acceleration * Time.fixedDeltaTime);
            print(Force);
            rb.AddForce(transform.forward * Force, ForceMode.VelocityChange);
        }

    }
}