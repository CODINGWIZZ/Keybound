using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomSound : MonoBehaviour
{
    [SerializeField] AudioClip[] sounds;
    AudioSource audioSource;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    void FixedUpdate()
    {
        int randomInterval = UnityEngine.Random.Range(30, 150);

        if(randomInterval > 100)
        {
            playSound();
        }
    }

    void playSound()
    {
        AudioClip clip = sounds[UnityEngine.Random.Range(0, sounds.Length)];
        audioSource.PlayOneShot(clip);
    }
}
