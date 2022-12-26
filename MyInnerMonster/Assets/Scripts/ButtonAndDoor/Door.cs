using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{

    public bool _blockDoor = false;
    public bool _isOpen = false;
    Vector2 _closePosition;
    Vector2 _openPosition;
    public float Y_openOffset;
    float _activeSpeed = 2f;
    // Start is called before the first frame update
    void Start()
    {
        _closePosition = transform.localPosition;
        _openPosition = new Vector2(_closePosition.x, _closePosition.y + Y_openOffset);
    }

    // Update is called once per frame
    void Update()
    {
        if (!_blockDoor)
        {

            if (!_isOpen)
            {
                transform.localPosition = Vector2.MoveTowards(transform.localPosition, _closePosition, _activeSpeed * Time.deltaTime);
            }
            else
            {
                transform.localPosition = Vector2.MoveTowards(transform.localPosition, _openPosition, _activeSpeed * Time.deltaTime);
            }
        }
        else
        {
            transform.localPosition = Vector2.MoveTowards(transform.localPosition, _openPosition, _activeSpeed * Time.deltaTime);
            if (transform.localPosition.y > _openPosition.y - 0.1 && transform.localPosition.y < _openPosition.y + 0.1)
            {
                _blockDoor = false;
            }
        }
                
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Block") || collision.CompareTag("Door") || collision.CompareTag("Black") || collision.CompareTag("White"))
        {
            _blockDoor = true;
        }
    }
}
