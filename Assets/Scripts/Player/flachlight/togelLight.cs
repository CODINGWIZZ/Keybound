using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class togelLight : MonoBehaviour
{
    public FlachlightScript flachlight;
    public Light light;
    public PlayerStats playerStats;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (flachlight.activ && playerStats.currentBattery > 0)
        {
            light.enabled = true;
        }
        else
        {
            light.enabled = false;
        }
    }
}
