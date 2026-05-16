using UnityEngine;

public class CheckpointManager : MonoBehaviour
{
    public static CheckpointManager instance;

    private Vector3 lastCheckpoint;
    
    private void Awake()
    {
        instance = this;
        lastCheckpoint = Vector3.zero;
    }

    public void SetCheckpoint(Vector3 position)
    {
        lastCheckpoint = position;
        Debug.Log("Checkpoint updated: " + position);

    }

    public Vector3 GetCheckpoint()
    {
        return lastCheckpoint;
    }
}
