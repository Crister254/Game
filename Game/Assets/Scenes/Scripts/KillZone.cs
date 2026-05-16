using UnityEngine;

public class KillZone : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
   {
        if (other.CompareTag("Player"))
        {
            other.transform.position = CheckpointManager.instance.GetCheckpoint();
        }
   }
}
