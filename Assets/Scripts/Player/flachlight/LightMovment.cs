using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightMovment : MonoBehaviour
{
    public Transform cameraTransform;

    public Vector2 lightOffSet;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(cameraTransform.position.x, cameraTransform.position.y + lightOffSet.x, cameraTransform.position.z + lightOffSet.y);
        cameraTransform.rotation = cameraTransform.rotation;
    }
}
