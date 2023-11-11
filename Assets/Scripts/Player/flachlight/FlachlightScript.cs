using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlachlightScript : MonoBehaviour
{
    public bool activ;
    public controles keyBindes;

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

        if (batery.currentBattery <= 0)
        {
            activ = false;
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
