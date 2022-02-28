using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public float speed = 10.0f;
    public float zoomSpeed = 10.0f;
    public float distance = 4.0f;

    public float heightOffset;
    public Transform target;
    float currentDistance;
    float distanceBack;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButton(1))
        {
            Vector3 angles = transform.eulerAngles;
            float dx = Input.GetAxis("Mouse Y");
            float dy = Input.GetAxis("Mouse X");
            //angles.x = Mathf.Clamp(angles.x + -dx * speed * Time.deltaTime, 0, 70);
            angles.x += -dx * speed * Time.deltaTime;
            angles.y += dy * speed * Time.deltaTime;
            transform.eulerAngles = angles;
        }

        distanceBack = Mathf.Clamp(distanceBack - Input.GetAxis("Mouse ScrollWheel") * zoomSpeed, 2, 10);

        RaycastHit hit;
        if(Physics.Raycast(GetTargetPos(), -transform.forward,out hit, distance))
        {
            currentDistance = hit.distance;
        }
        else
        {
            // relax the camera back to the desired distance
            currentDistance = Mathf.MoveTowards(currentDistance, distance, Time.deltaTime);
        }

        

        transform.position = GetTargetPos() - currentDistance * transform.forward;
    }

    Vector3 GetTargetPos()
    {
        return target.position + heightOffset * Vector3.up;
    }

}
