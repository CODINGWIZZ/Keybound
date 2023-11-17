using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    public float maxBattery;
    public float currentBattery;
    public float batteryDrain;

    public int amountOfKeys;
    private bool key;
    public List<bool> keys = new List<bool>();

    private void Awake()
    {
        for(int i = 0; i < amountOfKeys; i++)
        {
            keys.Add(key);
        }
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.M))
        {
            currentBattery = maxBattery;
        }
    }
}
