using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class togelLight : MonoBehaviour
{
    public FlachlightScript flachlight;
    public Light _light;
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
            _light.enabled = true;
        }
        else
        {
            _light.enabled = false;
        }
    }
}
