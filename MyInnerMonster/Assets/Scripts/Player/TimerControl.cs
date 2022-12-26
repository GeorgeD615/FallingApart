using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimerControl : MonoBehaviour
{
    [SerializeField] CountdownTimer timer;
    //private float cooldownTime = 5f;
    //private float blockTime = 0f;
    //public bool isBlocked = false;
    [SerializeField] private ControllBlack _controllBlack;

    void FixedUpdate()
    {
        if (_controllBlack.isBlackEnable/* && !isBlocked*/)
        {
            //blockTime = 0;
            //print("launching timer");
            //timer.wasEPressed = true;
            //isBlocked = true;
        }

        if (timer.isFinished)
        {
            //blockTime += Time.deltaTime;
            //if (/*isBlocked &&*/ ((blockTime - cooldownTime) > 0.0001f))
            //{
            //    blockTime = 0;
            //    //isBlocked = false;
            //}
        }

        //print(blockTime);
    }
}
