using UnityEngine;

public class Checkpoint : MonoBehaviour
{
    private bool activated = false;

    private void Start()
    {
        CheckpointManager.instance.RegisterCheckpoint();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && !activated)
        {
            activated = true;
            CheckpointManager.instance.ActivateCheckpoint(transform.position);
        }
    }
}
