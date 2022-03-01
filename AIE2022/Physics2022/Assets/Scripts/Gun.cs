using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
    public float damage = 10f;
    public float range = 20f;

    public Camera fpsCam;
    // Update is called once per frame
    void Update()
    {
        if(Input.GetButtonDown("Fire1"))
        {
            Shoot();
        }
    }

    void Shoot()
    {
        RaycastHit hit;
        if(Physics.Raycast(fpsCam.transform.position, fpsCam.transform.forward, out hit, range))
        {
            Target target = hit.transform.GetComponentInChildren<Target>();
            
            target.TakeDamage(damage);
            //if(hit.rigidbody != null)
            //    hit.rigidbody.AddForce(-hit.normal * 150);
        }
    }
}
