using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public float speed = 1f;
    public float zoomSpeed = 2f;
    public float distance = -0.5f;

    public float heightOffset;
    public Transform target;
    float currentDistance;
    float distanceBack;
    float verticalRot;
    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {

        Vector3 angles = transform.eulerAngles;
        float dx = Input.GetAxis("Mouse Y") * speed * Time.deltaTime;
        float dy = Input.GetAxis("Mouse X") * speed * Time.deltaTime;

        verticalRot -= dx;
        verticalRot = Mathf.Clamp(verticalRot, -90f, 90f);

        //angles.x = 
        //angles.y += dy * speed * Time.deltaTime;
        //transform.eulerAngles = angles;


        distanceBack = Mathf.Clamp(distanceBack - Input.GetAxis("Mouse ScrollWheel") * zoomSpeed, 2, 10);

        RaycastHit hit;
        if (Physics.Raycast(GetTargetPos(), -transform.forward, out hit, distance))
        {
            currentDistance = hit.distance;
        }
        else
        {
            // relax the camera back to the desired distance
            currentDistance = Mathf.MoveTowards(currentDistance, distance, Time.deltaTime);
        }

        transform.position = GetTargetPos() - currentDistance * transform.forward;
        transform.localRotation = Quaternion.Euler(verticalRot, 0, 0);
        target.Rotate(Vector3.up * dy);
    }

    Vector3 GetTargetPos()
    {
        return target.position + heightOffset * Vector3.up;
    }

}
