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
        
        if (Input.GetKey(KeyCode.W)){ // FORWARDS
            float Force = acceleration * Time.fixedDeltaTime;
            
            rb.AddForce(transform.forward * Force, ForceMode.VelocityChange);
        }// FORWARDS
    
       if (Input.GetKey(KeyCode.S)){ // BACKWARDS
            float Force = -(acceleration * Time.fixedDeltaTime);
            
            rb.AddForce(transform.forward * Force, ForceMode.VelocityChange);
        }// BACKWARDS

        // STEERING / TURNING
        float steeringInput = Input.GetAxisRaw("Horizontal");
        float turnAmount = steeringInput * turnSpeed * Time.fixedDeltaTime;

        transform.Rotate(Vector3.up, turnAmount);
        // STEERING / TURNING

        // cancelling lateral velocity for a type of "grip" effect
        Vector3 lateralVelocity = transform.right * Vector3.Dot(rb.linearVelocity, transform.right);
        float gripFactor = 0.9f; 
        rb.linearVelocity -= lateralVelocity * gripFactor;

    }
}