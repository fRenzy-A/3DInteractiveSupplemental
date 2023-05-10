using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteraction : MonoBehaviour
{
    [SerializeField]
    public GameObject currentInterObj = null;

    public InteractionObject currentInterObjScript = null;

    public GameObject interactPrompt;


    void Update()
    {
        if (Input.GetKey(KeyCode.E) && currentInterObj == true)
        {
            CheckInteraction();
        }

    }

    void CheckInteraction()
    {
        if (currentInterObjScript.interType == InteractionObject.InteractableType.nothing)
        {
            currentInterObjScript.Nothing();
        }
        else if (currentInterObjScript.interType == InteractionObject.InteractableType.info)
        {
            currentInterObjScript.Info();
        }

        else if (currentInterObjScript.interType == InteractionObject.InteractableType.pickup)
        {
            currentInterObjScript.Pickup();
        }
        else if (currentInterObjScript.interType == InteractionObject.InteractableType.dialogue)
        {
            currentInterObjScript.Dialogue();
        }
    }

    void OnTriggerEnter(Collider other)
    {
       if (other.CompareTag("InterObject") == true)
        {
            currentInterObj = other.gameObject;
            currentInterObjScript = currentInterObj.GetComponent<InteractionObject>();
            interactPrompt.SetActive(true);
        }
    }
    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("InterObject") == true)
        {
            currentInterObj = null;
            currentInterObjScript = null;
            interactPrompt.SetActive(false);
        }
    }
}

