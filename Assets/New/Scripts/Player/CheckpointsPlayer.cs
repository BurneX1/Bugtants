using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckpointsPlayer : MonoBehaviour
{
    CheckpointSystem checkpointSystem;
    public Vector3 playerInitialPosition;
    // Start is called before the first frame update
    void Start()
    {
        playerInitialPosition = transform.position;

        checkpointSystem = FindObjectOfType<CheckpointSystem>();
    }

    public void SetPosition(Vector3 p)
    {
        transform.position = p;
    }

    public void ResetPlayer()
    {
        if (checkpointSystem.CheckpointAvailable())
        {
            transform.position = checkpointSystem.GetCurrentCheckpointPosition();
        }
        else
        {
            transform.position = playerInitialPosition;
        }

    }
}
