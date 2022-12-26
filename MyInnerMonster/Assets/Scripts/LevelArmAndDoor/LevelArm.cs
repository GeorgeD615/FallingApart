using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelArm : MonoBehaviour
{
    [SerializeField] private Door door;
    [SerializeField] private Animator animator;

    public bool levelArmUsed = false;
    bool _canWhiteUseArm = false;
    bool _canBlackUseArm = false;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Black") && !levelArmUsed)
        {
            _canBlackUseArm = true;
        }
        if (other.CompareTag("White") && !levelArmUsed)
        {
            _canWhiteUseArm = true;
        }


    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Black") && !levelArmUsed)
        {
            _canBlackUseArm = false;
        }
        if (collision.CompareTag("White") && !levelArmUsed)
        {
            _canWhiteUseArm = false;
        }
    }

    private void Update()
    {
        if ((_canBlackUseArm || _canWhiteUseArm) && Input.GetKey(KeyCode.E))
        {
            FindObjectOfType<AudioManager>().Play("button");
            levelArmUsed = true;
            door._isOpen = true;
            animator.SetBool("Used", true);
        }
    }
}
