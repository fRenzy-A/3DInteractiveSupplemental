using StarterAssets;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class DialogueManager : MonoBehaviour
{
    public GameObject dialogueUI;
    public TMP_Text dialogueText;
    public GameObject player;
    public Animator animator;
    public TMP_Text dialogueName;

    public Queue<string> dialogue;


    void Start()
    {
        dialogue = new Queue<string>();
    }

    public void StartDialogue(string[] sentences, string nameOfNPC)
    {
        dialogue.Clear();
        dialogueUI.SetActive(true);

        dialogueName = GameObject.Find("NameOfNPC").GetComponent<TMP_Text>();

        dialogueName.text = nameOfNPC;

        SuspendPlayerControl();

        foreach (string currentLine in sentences)
        {
            dialogue.Enqueue(currentLine);
        }
        DisplayNextSentence();
    }

    void SuspendPlayerControl()
    {
        player.GetComponent<ThirdPersonController>().enabled = false;
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        player.GetComponent<PlayerInteraction>().enabled = false;

        animator.SetFloat("Speed", 0);
        
    }

    public void DisplayNextSentence()
    {
   
        if (dialogue.Count == 0)
        {
            EndDialogue();

            return;
        }
        string currentLine = dialogue.Dequeue();

        dialogueText.text = currentLine;
    }

    public void EndDialogue()
    {
        dialogueUI.SetActive(false);
        dialogue.Clear();

        player.GetComponent<ThirdPersonController>().enabled = true;
        player.GetComponent<PlayerInteraction>().enabled = true;
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }
}
