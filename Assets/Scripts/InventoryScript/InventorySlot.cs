using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[System.Serializable]
public class InventorySlot
{
    [SerializeField] private InventoryItemData itemData;
    [SerializeField] private int stackSize;

    public InventoryItemData ItemData => itemData;
    public int StackSize => stackSize;

    public InventorySlot(InventoryItemData sorce, int amount)
    {
        itemData = sorce;
        stackSize = amount;
    }

    public InventorySlot()
    {
        ClearSlot();
    }

    public void ClearSlot()
    {
        itemData = null;
        stackSize = -1;
    }

    public bool RomLeftInStack(int amountToAdd, out int amountRemaning)
    {
        amountRemaning = ItemData.Slot - stackSize;

        return RomLeftInStack(amountRemaning);

    }

    public bool RomLeftInStack(int amountToAdd)
    {
        if(stackSize + amountToAdd <= itemData.Slot)
        {
            return true;
        }
        else
        {
            return false;
        }
    }


    public void AddToStack(int amount)
    {
        stackSize += amount;
    }

    public void RemovFromStack(int amount)
    {
        stackSize -= amount;
    }
}
