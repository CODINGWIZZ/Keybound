using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    [SerializeField] List<Items> items;
    [SerializeField] Transform itemsParent;
    [SerializeField] Itemslot[] itemSlots;

    private void OnValidate()
    {
    }
}
