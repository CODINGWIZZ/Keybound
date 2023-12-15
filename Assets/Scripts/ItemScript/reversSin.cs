using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class reversSin : MonoBehaviour
{
    public HeadbobSystem headbob;
    public Movement movement;
    Vector3 StartPosition;
    public float move;

    void Start()
    {
        StartPosition = transform.localPosition;
    }

    void Update()
    {
        CheckForHeadbobTrigger();
        StopHeadBob();
        if (movement.isCrouched)
        {
            transform.localScale = new Vector3(755, 755 * 2f, 755);
            transform.position = new Vector3 (transform.position.x, transform.position.y, transform.position.z + move/100); 
        } else
        {
            transform.localScale = new Vector3(755, 755, 755);
            transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z - move/100);
        }
    }

    private void CheckForHeadbobTrigger()
    {
        float inputMagniute = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical")).magnitude;

        if (inputMagniute > 0)
        {
            StartHeadBob();
        }
    }

    private Vector3 StartHeadBob()
    {
        Vector3 position = Vector3.zero;

        position.y += -Mathf.Lerp(position.y, Mathf.Sin(Time.time * headbob.Frequency) * headbob.Amount * 0.8f, headbob.Smooth * Time.deltaTime);
        position.x += -Mathf.Lerp(position.x, Mathf.Cos(Time.time * headbob.Frequency / 2f) * headbob.Amount * 0.4f, headbob.Smooth * Time.deltaTime);

        transform.localPosition += position;

        return position;
    }

    private void StopHeadBob()
    {
        if (transform.localPosition == StartPosition) return;
        transform.localPosition = Vector3.Lerp(transform.localPosition, StartPosition, 1 * Time.deltaTime);
    }
}
