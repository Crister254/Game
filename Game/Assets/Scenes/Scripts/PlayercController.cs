using System;
using Unity.VisualScripting;
using UnityEngine;

public class PlayercController : MonoBehaviour

{


    private bool isGrounded;









    public float turnSpeed = 100f;

    public float acceleration = 30f; //hella goofy, 20 is too low, 100+ is too high 30-50?
    public float currentSpeed = 0f;


    // grip punishments are:
    // braking reduces grip by 0.12
    // steering reduces grip by 0.06
    // the threshhold to actually apply the lost grip is at 0.7, which is my reasoning to having ghostGrip

    public float Grip = 0.99f; 
    public float gripRestoreRate = 0.05f;
    public float gripSteerPunishment = 0.06f;
    public float gripBrakePunishment = 0.12f;
    public float currentGrip;
    public float ghostGrip;

    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        currentGrip = Grip;
        ghostGrip = Grip;
    }
    
    void FixedUpdate()
    {
        isGrounded = Physics.Raycast(transform.position, Vector3.down, 1f);
        print(ghostGrip + " " + currentGrip + " " + isGrounded);
        if (!isGrounded){ghostGrip = 0; return;}; 
        currentSpeed = transform.InverseTransformDirection(rb.linearVelocity).z; // snapshot the current speed

        // restore grip over time
        if (ghostGrip < Grip){
            ghostGrip += gripRestoreRate;
        }
        // ------------------------------------


        // STEERING / TURNING
        float steeringInput = Input.GetAxisRaw("Horizontal");
        float turnAmount = steeringInput * turnSpeed * Time.fixedDeltaTime;
        if (steeringInput != 0){
            ghostGrip -= gripSteerPunishment; // apply steering punishment to ghostGrip
        }

        transform.Rotate(Vector3.up, turnAmount);
        // STEERING / TURNING


        // BACKWARDS
       if (Input.GetKey(KeyCode.S)){ 
            float Force = -(0.7f * acceleration) - (currentSpeed/3f);
            ghostGrip -= gripBrakePunishment; // apply braking punishment to ghostGrip
            
            rb.AddForce(transform.forward * Force * Time.fixedDeltaTime, ForceMode.VelocityChange);
        }
        // BACKWARDS


        // FORWARDS
        if (Input.GetKey(KeyCode.W)){ 
            float Force = acceleration - currentSpeed/6f;

            rb.AddForce(transform.forward * Force * Time.fixedDeltaTime, ForceMode.VelocityChange);
        }
        // FORWARDS


        // cancelling lateral velocity for a type of "grip" effect
        Vector3 lateralVelocity = transform.right * Vector3.Dot(rb.linearVelocity, transform.right);
        rb.linearVelocity -= lateralVelocity * currentGrip;
        // ------------------------------------


        // correct and limit any overshoot
        if (ghostGrip > Grip){
            ghostGrip = Grip; //roof
        } else if (ghostGrip < 0f){
            ghostGrip = 0f; //floor
        }

        if (ghostGrip < 0.7f){ // if the ghost grip is below the threshhold, apply the grip, otherwise grant full grip
            currentGrip = ghostGrip;
        } else {
            currentGrip = Grip;
        }
    }
}