using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class positionkeeper : MonoBehaviour
{
    public Transform itemHolder;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = itemHolder.position;
        transform.rotation = itemHolder.rotation;
    }
}
