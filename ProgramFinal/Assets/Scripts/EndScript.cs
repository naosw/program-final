using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class EndScript : MonoBehaviour
{
    // initialize variables for sound effects
    [SerializeField] private AudioClip endClip;
    private AudioSource audioSource;
    [SerializeField] private AudioSource backgroundAudioSource;

    public GameObject endMessage;
    public GameObject player;

    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
    }

    // upon touching the exit zone, end the game and display a 'congrats' message
    private void OnCollisionEnter2D(Collision2D other)
    {
        endMessage.SetActive(true);
        Destroy(player);

        // stop the background track from playing
        backgroundAudioSource.Stop();

        // play sound effect for finishing the game
        audioSource.clip = endClip;
        audioSource.Play();
    }
}
