using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class EndScript : MonoBehaviour
{
    public GameObject endMessage;
    public GameObject player;

    // upon touching the exit zone, end the game and display a 'congrats' message
    private void OnCollisionEnter2D(Collision2D other)
    {
        endMessage.SetActive(true);
        Destroy(player);
        //UnityEditor.EditorApplication.isPaused = true;
    }
}
