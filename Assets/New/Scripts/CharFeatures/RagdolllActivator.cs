using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RagdolllActivator : MonoBehaviour
{
    public Animator anim;
    public GameObject ragdolModel;
    public Collider[] clasicColliders;
    public Rigidbody[] clasicRB;
    private Collider[] ragdollCol;
    private Rigidbody[] ragdollRB;

    private void Awake()
    {
        GetRagdoll();
    }

    private void GetRagdoll()
    {
        if (ragdolModel)
        {
            ragdollCol = ragdolModel.GetComponentsInChildren<Collider>();
            ragdollRB = ragdolModel.GetComponentsInChildren<Rigidbody>();
        }
    }

    public void RagdollSetActive(bool active)
    {
        if (ragdolModel == null) return;

        if (anim) anim.enabled = !active;


        foreach (Collider col in ragdollCol)
        {
            col.enabled = active;
        }
        foreach (Rigidbody rig in ragdollRB)
        {
            rig.isKinematic = !active;
        }

        foreach (Collider col in clasicColliders)
        {
            col.enabled = !active;
        }
        foreach (Rigidbody rig in clasicRB)
        {
            rig.isKinematic = active;
        }
    }
}
