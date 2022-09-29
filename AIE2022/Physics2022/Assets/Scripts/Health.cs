using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    public float maxHealth;
    
    public float currentHealth;
    Ragdoll ragdoll;
    // Start is called before the first frame update
    void Start()
    {
        ragdoll = GetComponent<Ragdoll>();
        currentHealth = maxHealth;
        var rigidBodies = GetComponentsInChildren<Rigidbody>();
        foreach(var rigidBody in rigidBodies)
        {
            HitBox hitbox = rigidBody.gameObject.AddComponent<HitBox>();
            hitbox.health = this;
        }
    }

    public void TakeDamage(float amount, Vector3 direction)
    {
        currentHealth -= amount;

        if (currentHealth <= 0.0f)
        {
            Die();
        }
    }
    void Die()
    {
        ragdoll.RagdollOn = true;
    }
}
