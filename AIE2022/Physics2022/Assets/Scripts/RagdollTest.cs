using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RagdollTest : MonoBehaviour
{
    Rigidbody[] rigidbodies;
    Animator animator;
    // Start is called before the first frame update
    void Start()
    {
        rigidbodies = GetComponentsInChildren<Rigidbody>();
        animator = GetComponent<Animator>();

        Deactivate();
    }

    public void Deactivate()
    {
        foreach (var rigidbody in rigidbodies)
        {
            rigidbody.isKinematic = true;
        }
        animator.enabled = true;
    }

    public void Activate()
    {
        foreach (var rigidbody in rigidbodies)
        {
            rigidbody.isKinematic = false;
        }
        animator.enabled = false;
    }
}
