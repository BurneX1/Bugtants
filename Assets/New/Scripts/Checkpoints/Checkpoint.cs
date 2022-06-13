using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Checkpoint : MonoBehaviour
{
    CheckpointSystem system;
    InputSystemActions inputStm;
    bool checkpointActivated = false;
    int checkpointIndex;
    public GameObject objectActivated;
    public GameObject objectDeactivated;

    public bool funtionactive;

    void Awake()
    {
        inputStm = new InputSystemActions();

        inputStm.GamePlay.Interact.performed += ctx => Function();
    }
    void Start()
    {
        Deactivate();
    }

    void Update()
    {
        
    }

    public void SetCheckpointSystem(CheckpointSystem c)
    {
        system = c;
    }

    private void OnTriggerEnter(Collider other)
    {
        CheckpointsPlayer player = other.GetComponent<CheckpointsPlayer>();
        if (player != null)
        {
            funtionactive = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        funtionactive = false;
    }

    public void Function()
    {
        if (funtionactive == true)
        {
            Activate();
            system.CheckpointActivated(checkpointIndex);
        }
        else return;
    }

    public void Activate()
    {
        checkpointActivated = true;
        objectActivated.SetActive(checkpointActivated);
        objectDeactivated.SetActive(!checkpointActivated);
    }

    public void Deactivate()
    {
        checkpointActivated = false;
        objectActivated.SetActive(checkpointActivated);
        objectDeactivated.SetActive(!checkpointActivated);
    }

    public void SetIndex(int i)
    {
        checkpointIndex = i;
    }

    public Vector3 GetCheckpointPosition()
    {
        return transform.position;
    }

    private void OnEnable()
    {
        inputStm.Enable();
    }
    private void OnDisable()
    {
        inputStm.Disable();
    }

}
