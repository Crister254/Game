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
        print("Upd");
        if (Input.GetKey(KeyCode.W)){
            float Force = acceleration * Time.fixedDeltaTime;
            rb.AddForce(transform.forward * Force, ForceMode.VelocityChange);
            print(Force);
        }
    
       if (Input.GetKey(KeyCode.S)){
            float Force = -(acceleration * Time.fixedDeltaTime);
            rb.AddForce(transform.forward * Force, ForceMode.VelocityChange);
        }

    }
}