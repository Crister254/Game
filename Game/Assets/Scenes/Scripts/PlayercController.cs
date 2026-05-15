using UnityEngine;

public class PlayercController : MonoBehaviour

{
    public float speed = 5f;

    void Update()
    {
        float moveX = Input.GetAxisRaw("Horizontal");
        float moveZ = Input.GetAxisRaw("Vertical");

        Vector3 movement = new Vector3(moveX, 0f, moveZ);

        transform.Translate(movement * speed * Time.deltaTime);
    }
}