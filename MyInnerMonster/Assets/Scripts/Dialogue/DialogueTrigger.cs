using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueTrigger : MonoBehaviour
{
    public DialogueManager[] managers;
    private int currIndex;
    private int nextIndex;

    public void TriggerDialogue()
    {
        managers[0].StartDialogue();
        currIndex = 0;
        nextIndex = 1;
    }

    public void LoadNextDialogue()
    {
        if (managers.Length > nextIndex && managers[currIndex].finished)
        {
            managers[nextIndex].StartDialogue();
            ++currIndex;
            ++nextIndex;
        }
    }
}