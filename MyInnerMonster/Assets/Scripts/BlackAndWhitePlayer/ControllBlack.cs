using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ControllBlack : MonoBehaviour
{

    public bool blackNearWhite;
    public bool canUseBlack = true;


    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Black"))
            blackNearWhite = true;
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Black"))
            blackNearWhite = false;
    }

    public BlackMovement _blackMovementScript;
    public SpriteRenderer _blackSpriteRenderer;
    public WhiteMovement _whiteMovementScript;
    public bool isBlackEnable = false;

    private void Start()
    {
        //_blackMovementScript.enabled = isBlackEnable;
        _blackSpriteRenderer.enabled = isBlackEnable;
    }
    private void Update()
    {
        
        if (canUseBlack && blackNearWhite && Input.GetKeyDown(KeyCode.Q))
        {
            FindObjectOfType<AudioManager>().Play("change");
            isBlackEnable = !isBlackEnable;
            //_blackMovementScript.enabled = isBlackEnable;
            _blackSpriteRenderer.enabled = isBlackEnable;
            _whiteMovementScript.enabled = !isBlackEnable;

        }
    }
}
