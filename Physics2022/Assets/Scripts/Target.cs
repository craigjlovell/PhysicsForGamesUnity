using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour
{
    Ragdoll ragdoll;

    private void Start()
    {
        ragdoll = GetComponentInChildren<Ragdoll>();
    }

    public float health = 50f;

    private void Update()
    {
        
    }

    public void TakeDamage(float amount)
    {            
        health -= amount;

        if(health <= 0f)
        {
            ragdoll.RagdollOn = true;
        }
    }
    void Die()
    {
        Destroy(gameObject);
    }

}
