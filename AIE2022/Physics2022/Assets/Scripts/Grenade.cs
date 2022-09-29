using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grenade : MonoBehaviour
{
    // Start is called before the first frame update
    float timer = 5;
    float countdown;
    float radius = 3;
    float force = 10;
    public float damage = 100;

    bool hasExploaded;
    public GameObject explodePart;
    Ragdoll rag;
    void Start()
    {
        countdown = timer;
    }

    // Update is called once per frame
    void Update()
    {
        countdown -= Time.deltaTime;
        if(Input.GetKeyDown(KeyCode.G))
        {
            Explode();
        }
    }
    
    void Explode()
    {
        GameObject spawn = Instantiate(explodePart, transform.position, transform.rotation);
        Destroy(spawn, 1);

        Collider[] colliders = Physics.OverlapSphere(transform.position, radius);
        foreach(Collider nearByObject in colliders)
        {
            Rigidbody rb = nearByObject.GetComponent<Rigidbody>();
            if(rb != null)
            {
                if (rb.GetComponent<Ragdoll>() && rb.tag == "enemy")
                {
                    rb.GetComponent<Ragdoll>().RagdollOn = true;
                    rb.GetComponent<Health>().TakeDamage(rb.GetComponent<Health>().currentHealth, Vector3.zero);
                }
                rb.AddExplosionForce(force, transform.position, radius, 1f, ForceMode.Impulse);
            }

        }
        hasExploaded = true;
        
        
        Destroy(gameObject);
    }
}
