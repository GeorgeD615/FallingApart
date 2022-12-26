using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonPrompt : MonoBehaviour
{
    public bool isTipButtonPressed = false;

    public Animator anim;

    public void OpenTips()
    {
        isTipButtonPressed = !isTipButtonPressed;
        anim.SetBool("isActive", isTipButtonPressed);
    }

}
