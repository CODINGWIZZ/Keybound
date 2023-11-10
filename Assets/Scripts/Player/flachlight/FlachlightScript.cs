using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlachlightScript : MonoBehaviour
{
    public bool activ;
    public KeyBindes keyBindes;

    public PlayerStats batery;

    private void Awake()
    {
        batery.currentBattery = batery.maxBattery;
    }

    private void Update()
    {
        if (Input.GetKeyDown(keyBindes.togelFicklampa))
        {
            activ = !activ;
        }

        if (activ)
        {
            drain();
        }

    }

    public void drain()
    {
        batery.currentBattery -= batery.batteryDrain * Time.deltaTime;
    }

}
