using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HotbarData : MonoBehaviour
{
    [SerializeField] private Image itemImage;
    [SerializeField] private InventorySlot assignedInventorySlot;

    public InventorySlot AssignedInventorySlot => assignedInventorySlot;

    public void Awake()
    {
        ClearSlort();
    }

    public void Init(InventorySlot slot)
    {
        assignedInventorySlot = slot;
        UpdateUISlot(slot);
    }

    public void UpdateUISlot(InventorySlot slot)
    {
        if(slot.ItemData != null)
        {
            itemImage.sprite = slot.ItemData.Icon;  
        }
    }

    public void ClearSlort()
    {
        assignedInventorySlot?.ClearSlot();
        itemImage.sprite = null;

    }
}
