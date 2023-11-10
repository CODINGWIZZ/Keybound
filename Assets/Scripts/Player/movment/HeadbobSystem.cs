using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeadbobSystem : MonoBehaviour
{
    [Range(0.001f, 0.01f)]
    public float Amount = 0.002f;

    [Range(1f, 30f)]
    public float Frequency = 10.0f;

    [Range(10f, 100f)]
    public float Smooth = 10.0f;

    Vector3 StartPosition;

    void Start()
    {
        StartPosition = transform.localPosition;
    }

    void Update()
    {
        CheckForHeadbobTrigger();
        StopHeadBob();
    }

    private void CheckForHeadbobTrigger()
    {
        float inputMagniute = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical")).magnitude;

        if(inputMagniute > 0)
        {
            StartHeadBob();
        }
    }

    private Vector3 StartHeadBob()
    {
        Vector3 position = Vector3.zero;

        position.y += Mathf.Lerp(position.y, Mathf.Sin(Time.time * Frequency) * Amount * 1.4f, Smooth * Time.deltaTime);
        position.x += Mathf.Lerp(position.x, Mathf.Cos(Time.time * Frequency / 2f) * Amount * 1.6f, Smooth * Time.deltaTime);

        transform.localPosition += position;

        return position;
    }

    private void StopHeadBob()
    {
        if (transform.localPosition == StartPosition) return;
        transform.localPosition = Vector3.Lerp(transform.localPosition, StartPosition, 1 * Time.deltaTime);
    }
}
