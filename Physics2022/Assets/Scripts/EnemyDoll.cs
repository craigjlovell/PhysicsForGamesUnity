using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDoll : MonoBehaviour
{
    public LayerMask enemyBase;
    private void OnTriggerEnter(Collider other)
    {
        // checks for the dummy's root
        if (other.gameObject.layer == 7)
        {

            // turns on dummy's ragdoll
            Ragdoll ragdoll = other.transform.GetChild(0).GetComponent<Ragdoll>();
            ragdoll.RagdollOn = true;
        }
    }
    
}
