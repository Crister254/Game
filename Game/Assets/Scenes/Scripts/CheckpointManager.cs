using UnityEngine;

public class CheckpointManager : MonoBehaviour
{
    public static CheckpointManager instance;

    private Vector3 lastCheckpointPos;
    private Quaternion lastCheckpointRot;

    private void Awake()
    {
        instance = this;
        lastCheckpointPos = new Vector3(0, 3, 0);
        lastCheckpointRot = Quaternion.identity;
    }

    public void SetCheckpoint(Vector3 position, Quaternion rotation)
    {
        lastCheckpointPos = position + Vector3.up * 3;
        lastCheckpointRot = rotation;
        Debug.Log("Checkpoint updated: " + position);

    }

    public (Vector3, Quaternion) GetCheckpoint()
    {
        return (lastCheckpointPos, lastCheckpointRot);
    }
}
