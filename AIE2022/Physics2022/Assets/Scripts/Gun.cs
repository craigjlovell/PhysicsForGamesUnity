using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
    public float damage = 10f;
    public float range = 20f;

    public ParticleSystem muzzleflash;
    public GameObject impact;

    public Camera fpsCam;

    bool isShooting;
    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            Shoot();
            isShooting = true;
        }
        else
        {
            isShooting = false;
        }

    }

    void Shoot()
    {
        muzzleflash.Emit(1);
        RaycastHit hit;
        if (Physics.Raycast(fpsCam.transform.position, fpsCam.transform.forward, out hit, range))
        {
            Health target = hit.transform.GetComponentInChildren<Health>();
            
            if(target != null)
                target.TakeDamage(damage, transform.forward);
            if(hit.rigidbody != null)
                hit.rigidbody.AddForce(-hit.normal * 150);
        }
        GameObject impactGo = Instantiate(impact, hit.point, Quaternion.LookRotation(hit.normal));
        Destroy(impactGo, 2f);
    }

    void NotShooting()
    {

    }
}
