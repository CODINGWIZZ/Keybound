using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using System.Linq;

[System.Serializable]
public class InvnetorySystem
{
    [SerializeField] private List<InventorySlot> inventorySlots;


    public List<InventorySlot> InventorySlots => inventorySlots;

    public int InvnetorySize => InventorySlots.Count;

    public UnityAction<InventorySlot> OnInventorySlotChanged;

    public InvnetorySystem(int size)
    {
        inventorySlots = new List<InventorySlot>(size);

        for (int i = 0; i < size; i++)
        {
            inventorySlots.Add(new InventorySlot());
        }
    }

    public bool AddToInvneoty(InventoryItemData itemToAdd, int index)
    {
        inventorySlots[index-1] = new InventorySlot(itemToAdd, index);
        return true;
    }
}
