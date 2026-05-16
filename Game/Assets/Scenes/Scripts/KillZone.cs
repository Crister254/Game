using UnityEngine;

public class KillZone : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
   {
        if (other.CompareTag("Player"))
        {
            var (checkpointPos, checkpointRot) = CheckpointManager.instance.GetCheckpoint();
            other.transform.position = checkpointPos;
            other.transform.rotation = checkpointRot;
            other.GetComponent<Rigidbody>().linearVelocity = Vector3.zero;
            other.GetComponent<Rigidbody>().angularVelocity = Vector3.zero;
        }
   }
}
