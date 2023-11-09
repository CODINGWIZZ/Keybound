using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class hottbar : MonoBehaviour
{
    public int slot;
    public Sprite display;
    public Image img;

    public InvnetoryHolder inv;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (inv.InvnetorySystem.InventorySlots[slot-1].ItemData != null)
        {
            display = inv.InvnetorySystem.InventorySlots[slot-1].ItemData.Icon;
        }
        else
        {
            display = null;
        }
        img.sprite = display;
    }
}
