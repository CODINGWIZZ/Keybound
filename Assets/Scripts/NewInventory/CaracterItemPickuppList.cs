using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CaracterItemPickuppList : MonoBehaviour
{
    [SerializeField] private int Slots;
    [SerializeField] private List<InventoryItemData> item = new List<InventoryItemData>();

    private void Awake()
    {
        for (int i = 0; i < Slots; i++)
        {
            item[i] = new InventoryItemData();
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        Debug.Log(item.Count);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
