using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorController : MonoBehaviour
{
    private Animator doorAnimator;
    public GameObject doorSound;

    private bool doorOpen = false;

    private void Awake()
    {
        doorAnimator = gameObject.GetComponent<Animator>();
    }

    void Start()
    {
        // doorSound.SetActive(false);
    }

    public void PlayAnimation()
    {
        if(doorAnimator.GetCurrentAnimatorStateInfo(0).normalizedTime > 1 && !doorAnimator.IsInTransition(0))
        {
            if (!doorOpen)
            {
                doorAnimator.Play("DoorOpen", 0, 0.0f);
                doorOpen = true;
            }
            else
            {
                doorAnimator.Play("DoorClose", 0, 0.0f);
                doorOpen = false;
            }

            doorSound.GetComponent<AudioSource>().Play(0);
            // yield return new WaitForSeconds(1.5f);
        }
    }
}
