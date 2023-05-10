using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using JetBrains.Annotations;
using StarterAssets;

public class InteractionObject : MonoBehaviour
{
    public enum InteractableType
    {
        nothing,
        info,
        pickup,
        dialogue
    }

    [Header("Type of Interactable")]
    public InteractableType interType;

    [Header("What item")]
    public string item;
    [Header("Item to give directly")]
    public bool willIGiveItemDirectly;
    public string giveItem;

    [Header("Simple info Message")]
    public string infoMessage;
    //private TMP_Text infoText;

    [Header("Dialogue Text")]
    [TextArea]
    public string[] firstTimeDialogue;
    [TextArea]
    public string[] pendingDialogue;

    [TextArea]
    public string[] ifQuestDoneDialogue;
    [TextArea]
    public string[] epilogueDialogue;

    [Header("Disappear Upon Mission Complete")]
    public bool willIDisappear;


    public bool nowTalked;
    public bool gotItemTest;
    public bool questDone;

    public GameObject activateThisItem;

    public PlayerInventory playerScript;
    public PlayerInteraction playerInteraction;
    public DialogueManager dialogueManager;
    public GameObject infoUI;
    public void Start()
    {
        playerScript = GameObject.Find("PlayerArmature").GetComponent<PlayerInventory>();
        playerInteraction = GameObject.Find("PlayerArmature").GetComponent<PlayerInteraction>();
        dialogueManager = GameObject.Find("DialogueManager").GetComponent<DialogueManager>();
    }

    public void Nothing()
    {
        Debug.LogWarning(this.gameObject.name + " has not type set");
    }

    public void Info()
    {
        FindObjectOfType<InfoManager>().ShowInfo(infoMessage);
    }

    public void Pickup()
    {
        FindObjectOfType<InfoManager>().ShowInfo(infoMessage);
        playerScript.inventory.Add(item);   
        this.gameObject.SetActive(false);
        playerInteraction.currentInterObjScript = null;
        playerInteraction.currentInterObj = null;
    }

    public void Dialogue()
    {
        if (!nowTalked)
        {
            FindObjectOfType<DialogueManager>().StartDialogue(firstTimeDialogue,gameObject.name);
            nowTalked = true;
        }
        else
        {
            FindObjectOfType<DialogueManager>().StartDialogue(pendingDialogue, gameObject.name);
        }
        if (questDone)
        {
            FindObjectOfType<DialogueManager>().StartDialogue(epilogueDialogue, gameObject.name);
        }
        if (playerScript.inventory.Contains(item))
        {

            FindObjectOfType<DialogueManager>().StartDialogue(ifQuestDoneDialogue, gameObject.name);
            if (willIGiveItemDirectly)
            {
                playerScript.inventory.Add(giveItem);
            }
            else
            {
                activateThisItem.SetActive(true);
            }


            questDone = true;
            playerScript.inventory.Remove(item);       
        }


    }

    
}
