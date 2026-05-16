using System.Numerics;
using UnityEngine;

public class CameraController : MonoBehaviour
{

    public Transform carTransform; 
    
    public float distance = 6f;
    public float height = 3f;

    public float smoothSpeed = 5f;

    void LateUpdate()
    {
        if (carTransform == null) return;

        UnityEngine.Vector3 targetPos = carTransform.position - (carTransform.forward * distance) + (UnityEngine.Vector3.up * height);
        transform.position = UnityEngine.Vector3.Lerp(transform.position, targetPos, smoothSpeed * Time.deltaTime);
        transform.LookAt(carTransform.position + UnityEngine.Vector3.up);
        
    }
}
