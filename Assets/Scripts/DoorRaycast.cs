using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorRaycast : MonoBehaviour
{
    [SerializeField] private int rayLength = 5;
    [SerializeField] private LayerMask layerMaskInteract;
    [SerializeField] private string excludeLayerName = null;

    private bool doOnce;

    private DoorController raycastObject;

    private KeyCode openDoorKey = KeyCode.E;

    private const string interactableTag = "InteractiveObject";

    void Update()
    {
        RaycastHit hit;
        Vector3 forward = transform.TransformDirection(Vector3.forward);

        int mask = 1 << LayerMask.NameToLayer(excludeLayerName) | layerMaskInteract.value;

        if(Physics.Raycast(transform.position, forward, out hit, rayLength, mask))
        {
            if(hit.collider.CompareTag(interactableTag))
            {
                if(!doOnce)
                {
                    raycastObject = hit.collider.gameObject.GetComponent<DoorController>();
                }

                doOnce = true;

                if(Input.GetKeyDown(openDoorKey))
                {
                    raycastObject.PlayAnimation();
                }
            }
        }
    } 
}
