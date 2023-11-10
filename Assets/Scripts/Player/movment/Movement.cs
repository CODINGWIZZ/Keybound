using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

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

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        capsuleCollider = GetComponent<CapsuleCollider>();
        originalCapsuleCenter = capsuleCollider.center;
        capsuleHeight = capsuleCollider.height;
        originalWalkSpeed = walkSpeed;
    }

    void Update()
    {
        if(enableCrouch)
        {
            if(Input.GetKeyDown(keyBindes.croutch) && !holdToCrouch)
            {
                Crouch();
            }

            if(Input.GetKeyDown(keyBindes.croutch) && holdToCrouch)
            {
                isCrouched = true;
                Crouch();
            } else if(Input.GetKeyUp(keyBindes.croutch) && holdToCrouch)
            {
                isCrouched = false;
                Crouch();
            }
        }

        CheckGround();
    }

    void FixedUpdate()
    {
        if(enableWalk)
        {
            playerInput = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
            playerInput = transform.TransformDirection(playerInput) * walkSpeed;

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
        if (!isCrouched)
        {
            DOTween.To(() => capsuleCollider.center,
                x => capsuleCollider.center = x,
                originalCapsuleCenter, 2);

            DOTween.To(() => capsuleCollider.height,
                x => capsuleCollider.height = x, 2,
                2);

            DOTween.To(() => cameraPivot.transform.localPosition,
                x=> cameraPivot.transform.localPosition = x,
                new Vector3(0, 0.5f, 0), 2);

            DOTween.To(() => walkSpeed,
                x => walkSpeed = x, originalWalkSpeed,
                2);

            isCrouched = true;
        } else
        {
            DOTween.To(() => capsuleCollider.center,
                x => capsuleCollider.center = x,
                new Vector3(0, -0.5f, 0), 2);

            DOTween.To(() => capsuleCollider.height,
                x => capsuleCollider.height = x, 1,
                2);

            DOTween.To(() => cameraPivot.transform.localPosition,
                x => cameraPivot.transform.localPosition = x,
                new Vector3(0, 0.0f, 0), 2);

            DOTween.To(() => walkSpeed,
                x => walkSpeed = x, speedReduction,
                2);

            isCrouched = false;
        }
    }
}
