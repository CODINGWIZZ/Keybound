using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseMovement : MonoBehaviour
{
    public Vector2 rotationRange = new Vector3();
    public float rotationSpeed = 10f;
    public float dampingTime = 0.2f;

    public Transform orientation;

    Vector3 targetAngles;
    Vector3 followAngles;
    Vector3 followVelocity;
    Quaternion originalRotation;

    float yRotation;
    float xRotation;

    void Start()
    {
        originalRotation = transform.localRotation;

        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }
    void Update()
    {
        transform.localRotation = originalRotation;

        float mouseX = Input.GetAxis("Mouse X");
        float mouseY = Input.GetAxis("Mouse Y");

        yRotation += mouseX * rotationSpeed;

        xRotation -= mouseY * rotationSpeed;
        xRotation = Mathf.Clamp(xRotation, -90f, 90f);

        targetAngles.y += mouseX * rotationSpeed;
        targetAngles.x += mouseY * rotationSpeed;

        targetAngles.x = Mathf.Clamp(targetAngles.x, -90f, 90f);

        followAngles = Vector3.SmoothDamp(followAngles, targetAngles, ref followVelocity, dampingTime);

        transform.rotation = originalRotation * Quaternion.Euler(-followAngles.x, followAngles.y, 0);
        orientation.rotation = originalRotation * Quaternion.Euler(0, followAngles.y, 0);
    }
}
