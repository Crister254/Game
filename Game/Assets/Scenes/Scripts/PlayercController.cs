using UnityEngine;

public class PlayercController : MonoBehaviour

{
    public float acclerantion = 10f;
    public float turnSPeed = 100f;

    private Rigidbody rb;
    
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
       


        if (Input.GetKey(KeyCode.W)){
            float Force = acclerantion * Time.fixedDeltaTime;
            rb.AddForce(transform.forward * Force, ForceMode.VelocityChange);
        }
    
       
    }
}