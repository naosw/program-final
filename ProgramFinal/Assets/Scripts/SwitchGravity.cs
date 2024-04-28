using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchGravity : MonoBehaviour
{
    [SerializeField] public int gravity = 1;
    private Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        // used for purpose of manually setting object gravity before play
        rb.gravityScale *= gravity;

        // used for objects that have gravity reversed from the start
        if (gravity == -1) transform.Rotate(180, 0, 0);
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Q))
        {
            // reverse gravity for any object with script, flip their sprite
            rb.gravityScale *= -1;
            transform.Rotate(180, 0, 0);
        }
    }
}
