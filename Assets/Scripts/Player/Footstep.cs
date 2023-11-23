using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Footstep : MonoBehaviour
{
    public GameObject footsteps;
    void Start()
    {
        footsteps.SetActive(false);
    }
    void Update()
    {
        if(Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.D))
        {
            PlayFootsteps();
        }
        
        if (Input.GetKeyUp(KeyCode.W) || Input.GetKeyUp(KeyCode.S) || Input.GetKeyUp(KeyCode.A) || Input.GetKeyUp(KeyCode.D))
        {
            StopFootsteps();
        }
    }

    public void PlayFootsteps()
    {
        footsteps.SetActive(true);
    }

    public void StopFootsteps()
    {
        footsteps.SetActive(false);
    }
}
