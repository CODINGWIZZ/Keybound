using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SphereCollider))]
public class ItemPickUp : MonoBehaviour
{
    [SerializeField] private int pickupSlot;

    public float PickUpRadius;
    public InventoryItemData itemData;

    private SphereCollider myColider;

    private void Awake()
    {
        myColider = GetComponent<SphereCollider>();
        myColider.isTrigger = true;
        myColider.radius = PickUpRadius;
    }

    private void OnTriggerEnter(Collider other)
    {
        var inventory = other.transform.GetComponent<InvnetoryHolder>();
        if (!inventory) return;

        if (inventory.InvnetorySystem.AddToInvneoty(itemData, itemData.Slot))
        {
            Destroy(this.gameObject);
        }
    }
}
