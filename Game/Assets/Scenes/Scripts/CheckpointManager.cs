using UnityEngine;

public class CheckpointManager : MonoBehaviour
{
    public static CheckpointManager instance;

    private int totalCheckpoints = 0;
    private int activatedCheckpoints = 0;

    private Vector3 lastCheckpointPos;

    private void Awake()
    {
        instance = this;
        lastCheckpointPos = Vector3.zero; // por si no has tocado ninguno
    }

    public void RegisterCheckpoint()
    {
        totalCheckpoints++;
    }

    public void ActivateCheckpoint(Vector3 pos)
    {
        activatedCheckpoints++;
        lastCheckpointPos = pos; // ← guardamos la posición del checkpoint activado
    }

    public bool AllCheckpointsActivated()
    {
        return activatedCheckpoints >= totalCheckpoints;
    }

    public Vector3 GetCheckpoint()
    {
        return lastCheckpointPos;
    }
}
