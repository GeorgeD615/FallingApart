using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour
{
    public TMPro.TextMeshProUGUI nameText;
    public TMPro.TextMeshProUGUI dialogueText;
    public GameObject continueButton;
    public GameObject dialogueBox;
    public bool finished;

    public Dialogue dialogue;

    private Queue<string> sentences;

    void Start()
    {
        finished = false;
        continueButton.SetActive(false);
        dialogueBox.SetActive(false);
        sentences = new Queue<string>();
    }

    public void StartDialogue()
    {
        continueButton.SetActive(true);
        dialogueBox.SetActive(true);
        nameText.text = dialogue.name;
        sentences.Clear();
        foreach (string sentence in dialogue.sentences)
        {
            sentences.Enqueue(sentence);
        }
        DisplayNextSentence();
    }

    public void DisplayNextSentence()
    {
        if (sentences.Count == 0)
        {
            EndDialogue();
            return;
        }
        string sentence = sentences.Dequeue();
        StopAllCoroutines();
        StartCoroutine(TypeSentence(sentence));
    }

    IEnumerator TypeSentence(string sentence)
    {
        dialogueText.text = "";
        foreach (char letter in sentence.ToCharArray())
        {
            dialogueText.text += letter;
            yield return new WaitForSeconds(0.1f);
        }
    }

    void EndDialogue()
    {
        continueButton.SetActive(false);
        dialogueBox.SetActive(false);
        finished = true;
    }
}