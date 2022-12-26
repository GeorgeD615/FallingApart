using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisableButton : MonoBehaviour
{
    public GameObject button;

    public void Disable()
    {
        button.SetActive(false);
    }
}
