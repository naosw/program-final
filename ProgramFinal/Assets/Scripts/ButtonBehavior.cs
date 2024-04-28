using System.Collections;
using System.Collections.Generic;
using System.Xml.Linq;
using Unity.VisualScripting;
using UnityEngine;

public class ButtonBehavior : MonoBehaviour
{
    public GameObject door;

    // sprites needed for button being pushed and un-pushed
    public SpriteRenderer spriteRenderer;
    public Sprite defaultSprite;
    public Sprite pushedSprite;

    // variable for how far the "door" travels, change when needed
    public float distance = 5;

    // upon button push, move the corresponding door out of the way
    // change button sprite to a pushed-down version
    private void OnCollisionEnter2D(Collision2D other)
    {
        door.transform.position += transform.up * distance;
        spriteRenderer.sprite = pushedSprite;
    }

    // upon the button no longer being pushed, undo whatever effect is generated, change sprite back to unpushed version
    private void OnCollisionExit2D(Collision2D other)
    {
        door.transform.position += transform.up * (distance * -1);
        spriteRenderer.sprite = defaultSprite;
    }
}
