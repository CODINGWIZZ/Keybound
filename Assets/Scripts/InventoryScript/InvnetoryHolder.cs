using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;


[System.Serializable]
public class InvnetoryHolder : MonoBehaviour
{
    [SerializeField] private int inventorySize;

    [SerializeField] protected InvnetorySystem invnetorySystem;

    public InvnetorySystem InvnetorySystem => invnetorySystem;

    public static UnityAction<InvnetorySystem> OnDynamicInvnetoryDisplayRequested;

    private void Awake()
    {
        invnetorySystem = new InvnetorySystem(inventorySize);
    }
}
