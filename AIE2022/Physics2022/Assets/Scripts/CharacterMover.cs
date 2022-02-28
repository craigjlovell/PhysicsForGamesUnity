using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMover : MonoBehaviour
{
    public float speed = 10;
    public int jumpStrength = 5;

    private bool isGrounded;
    private bool jumpInput;
    private bool shift;


    CharacterController cc;
    Animator aa;
    Transform cam;

    Vector2 moveInput = new Vector2();
    Vector3 velocity;

    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;

        cc = GetComponent<CharacterController>();
        aa = GetComponentInChildren<Animator>();
        cam = Camera.main.transform;
    }

    // Update is called once per frame
    void Update()
    {
        moveInput.x = Input.GetAxis("Horizontal");
        moveInput.y = Input.GetAxis("Vertical");
        jumpInput = Input.GetButton("Jump");

        aa.SetFloat("Forwards", moveInput.y);
        aa.SetBool("Jump", !isGrounded);

        aa.SetBool("Crouch", Input.GetKey(KeyCode.LeftShift));
    }

    void FixedUpdate()
    {
        Vector3 camForward = cam.forward;
        camForward.y = 0;
        camForward.Normalize();

        Vector3 camRight = cam.right;
        transform.forward = camForward;

        Vector3 delta = (moveInput.x * camRight + moveInput.y * camForward) * speed;
        if(isGrounded || moveInput.x != 0 || moveInput.y != 0)
        {
            velocity.x = delta.x;
            velocity.z = delta.z;
        }

        if (jumpInput && isGrounded)
            velocity.y = jumpStrength;

        if (isGrounded && velocity.y < 0)
            velocity.y = 0;

        // apply gravity after zero velocity so we register as grounded still
        velocity += Physics.gravity * Time.fixedDeltaTime;
        if(!isGrounded)
            hitDirection = Vector3.zero;

        // slide objects off surface they're hanging on to
        if (moveInput.x == 0 && moveInput.y == 0)
        {
            Vector3 horizontalHitDirection = hitDirection;
            horizontalHitDirection.y = 0;
            float displacement = horizontalHitDirection.magnitude;
            if (displacement > 0)
                velocity -= 0.2f * horizontalHitDirection / displacement;
        }

        cc.Move(velocity * Time.deltaTime);
        isGrounded = cc.isGrounded;

    }

    public Vector3 hitDirection;
    private void OnControllerColliderHit(ControllerColliderHit hit)
    {
        hitDirection = hit.point - transform.position;
    }

}
