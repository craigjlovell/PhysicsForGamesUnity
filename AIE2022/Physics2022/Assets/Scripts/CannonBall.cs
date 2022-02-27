using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class CannonBall : MonoBehaviour
{
    public float forceOfFire = 1000;

    private bool fire = false;
    private bool canFire = true;

    Rigidbody rigidbody = null;
    // Start is called before the first frame update
    void Awake()
    {
        rigidbody = GetComponent<Rigidbody>();
        rigidbody.isKinematic = true;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.anyKeyDown && canFire)
        {
            rigidbody.isKinematic=false;
            rigidbody.AddForce(transform.forward * forceOfFire);
            canFire = false;
        }
    }
}
