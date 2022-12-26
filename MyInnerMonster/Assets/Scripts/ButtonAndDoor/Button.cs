using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Button : MonoBehaviour
{
    public Animator animator;
    [SerializeField] private Door door;
   
    public bool buttonPressed = false;
    private bool whitePress = false;
    private bool blackPress = false;
    private bool blockPress = false;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if ((other.CompareTag("White") || other.CompareTag("Black") || other.CompareTag("Block")) && !buttonPressed)
        {
            buttonPressed = true;
            FindObjectOfType<AudioManager>().Play("button");
        }

        if (other.CompareTag("White"))
        {
            whitePress = true;
        }
        if (other.CompareTag("Black"))
        {
            blackPress = true;
        }
        if (other.CompareTag("Block"))
        {
            blockPress = true;
        }

    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("White"))
        {
            whitePress = false;
        }
        if (collision.CompareTag("Black"))
        {
            blackPress = false;
        }
        if (collision.CompareTag("Block"))
        {
            blockPress = false;
        }

        if (!whitePress && !blackPress && !blockPress)
        {
            buttonPressed = false;
        }
    }

    private void FixedUpdate()
    {
        if (whitePress || blackPress || blockPress)
        {
            door._isOpen = true;
            animator.SetBool("Pressed", true);
        }
        else
        {
            door._isOpen = false;
            animator.SetBool("Pressed", false);
        }
    }


}
