using UnityEngine;

public class Goal : MonoBehaviour
{
    public GameObject winScreen;

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("GOAL DETECTA"); // ← AQUÍ MISMO

        if (other.CompareTag("Player"))
        {
            if (CheckpointManager.instance.AllCheckpointsActivated())
            {
                winScreen.SetActive(true);
            }
        }
    }
}
