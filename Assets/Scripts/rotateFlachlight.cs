using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rotateFlachlight : MonoBehaviour
{

    public Transform rotationPoint;
    public Quaternion rotationOffset;
    public Vector3 positoiOffset;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.rotation = new Quaternion(rotationPoint.rotation.x * rotationOffset.x, rotationPoint.rotation.y * rotationOffset.y, rotationPoint.rotation.z * rotationOffset.z, rotationPoint.rotation.w * rotationOffset.w);
        transform.position = new Vector3(rotationPoint.position.x * positoiOffset.x, rotationPoint.position.y * positoiOffset.y, rotationPoint.position.z * positoiOffset.z);
    }
}
