using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightControler : MonoBehaviour
{
    public Light ljus;

    public controles controles;
    public PlayerStats playerStats;
    public FlachlightScript flachlight;

    public Transform camratransform;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(flachlight.activ && playerStats.currentBattery > 0)
        {
            ljus.enabled = true;
        }
        else
        {
            ljus.enabled = false;
        }


        transform.rotation = new Quaternion(camratransform.rotation.x, transform.rotation.y, transform.rotation.z, transform.rotation.w);
    }
}
