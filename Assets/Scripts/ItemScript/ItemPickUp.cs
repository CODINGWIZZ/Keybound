using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SphereCollider))]
public class ItemPickUp : MonoBehaviour
{
    public float PickUpRadius;
    public float pickUpDistense;

    public controles controles;

    public Transform player;

    public InventoryItemData itemData;
    public PlayerStats playerStats;

    private SphereCollider myColider;
    public Collider collider;

    private void Awake()
    {
        myColider = GetComponent<SphereCollider>();
        myColider.isTrigger = true;
        myColider.radius = PickUpRadius;
    }

    private void Update()
    {

        if (Vector3.Distance(player.position, transform.position) <= pickUpDistense && Input.GetKeyDown(controles.interackt))
        {
            if (itemData.clas == "pick")
            {
                var inventory = collider.transform.GetComponent<InvnetoryHolder>();
                if (inventory.InvnetorySystem.AddToInvneoty(itemData, itemData.Slot))
                {
                    Destroy(this.gameObject);
                }
            }
            if(itemData.clas == "key")
            {
                for(int i = 0; i < playerStats.keys.Count; i++)
                {
                    if(playerStats.keys[i] == true)
                    {
                        continue;
                    }

                    if(playerStats.keys[i] == false)
                    {
                        playerStats.keys[i] = true;
                        Destroy(this.gameObject);
                        break;
                    }
                }
            }
        }
    }

    /*private void PickPocketedIt(Collider other)
    {

        
        var inventory = other.transform.GetComponent<InvnetoryHolder>();
        if (!inventory) return;

        if (inventory.InvnetorySystem.AddToInvneoty(itemData, itemData.Slot))
        {
            Destroy(this.gameObject);
        }
    }*/
}
