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

        // transform.rotation = Quaternion.Euler(xRotation, yRotation, 0);
        // orientation.rotation = Quaternion.Euler(0, yRotation, 0);

        targetAngles.y = yRotation;
        targetAngles.x = xRotation;

        followAngles = Vector3.SmoothDamp(followAngles, targetAngles, ref followVelocity, dampingTime);

        transform.localRotation = Quaternion.Euler(followAngles.x, followAngles.y, 0);
        orientation.rotation = Quaternion.Euler(0, followAngles.y, 0);
        
        // float a = transform.localRotation.y
        // orientation.transform.localRotation = new Quaternion (0, -a, 0, 0);
    }
}
