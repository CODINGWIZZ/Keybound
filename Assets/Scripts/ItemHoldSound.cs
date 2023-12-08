using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemHoldSound : MonoBehaviour
{
    [SerializeField] AudioClip[] itemSounds;
    AudioSource audioSource;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    public void playItemSound()
    {
        AudioClip clip = itemSounds[0];
        audioSource.PlayOneShot(clip);
    }
}
