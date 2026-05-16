using UnityEngine;

public class Checkpoint : MonoBehaviour
{

    private bool isTaken = false;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && !isTaken)
        {
            isTaken = true;
            CheckpointManager.instance.SetCheckpoint(transform.position, transform.rotation);
        }
    }
}
