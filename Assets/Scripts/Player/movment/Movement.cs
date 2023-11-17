using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    [Space(20)]
    public bool enableWalk = true;
    private Rigidbody rb;
    public float walkSpeed = 5f;
    Vector3 playerInput;
    Vector3 velocity;
    Vector3 velocityChange;

    [Space(20)]
    private float originalWalkSpeed;
    private bool isGrounded;

    [Space(20)]
    public bool enableCrouch = true;
    public bool holdToCrouch = true;
    public controles keyBindes;
    public float crouchHeight = .75f;
    public float speedReduction = .5f;
    public CapsuleCollider capsuleCollider;
    public Transform cameraPivot;
    private bool isCrouched = false;
    private Vector3 originalCapsuleCenter;
    private Vector3 jointOriginalPosition;
    private float capsuleHeight;

    [Space(20)]
    public bool enableHeadBob = true;
    public HeadbobSystem headBober;

    private float startYScale;
    private bool canStand = true;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        capsuleCollider = GetComponent<CapsuleCollider>();
        originalCapsuleCenter = capsuleCollider.center;
        capsuleHeight = capsuleCollider.height;
        originalWalkSpeed = walkSpeed;
        startYScale = transform.localScale.y;
    }

    void Update()
    {
        if(enableCrouch)
        {
            Crouch();
        }

        CheckGround();
    }

    void FixedUpdate()
    {
        if(enableWalk)
        {
            playerInput = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
            playerInput = transform.TransformDirection(playerInput) * walkSpeed * (!isCrouched ? 1 : speedReduction);

            velocity = rb.velocity;
            velocityChange = (playerInput - velocity);

            velocityChange.y = 0;

            rb.AddForce(velocityChange, ForceMode.VelocityChange);
        }
    }

    private void CheckGround()
    {
        Vector3 origin = new Vector3(transform.position.x, transform.position.y - (transform.localScale.y * .5f), transform.position.z);
        Vector3 direction = transform.TransformDirection(Vector3.down);

        float distance = .75f;

        if(Physics.Raycast(origin, direction, out RaycastHit hit, distance))
        {
            isGrounded = true;
        } else
        {
            isGrounded = false;
        }
    }

    private void Crouch()
    {
        if (Physics.Raycast(cameraPivot.transform.position, Vector3.up, startYScale - crouchHeight + 0.2f))
        {
            canStand = false;
        }
        else
        {
            canStand = true;
        }

        if(Input.GetKey(keyBindes.croutch))
        {
            if(!isCrouched)
            {
                isCrouched = true;

                transform.localScale = new Vector3(transform.localScale.x, crouchHeight, transform.localScale.z);
                rb.AddForce(Vector3.down * 5f, ForceMode.Impulse);
            }
        } else
        {
            if(isCrouched && canStand)
            {
                isCrouched = false;

                transform.localScale = new Vector3(transform.localScale.x, startYScale, transform.localScale.z);
            }
        }
    }   
}
