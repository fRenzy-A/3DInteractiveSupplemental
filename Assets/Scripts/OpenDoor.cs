using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenDoor : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject door;
    [Header("Door Speed")]
    public float doorOpenSpeed = 2.0f;
    bool playerIsClose;
    bool goOpen;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.E) && playerIsClose == true)
        {
            goOpen = true;
        }
        DoorOpen();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") == true)
        {
            playerIsClose = true;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        playerIsClose = false;
    }

    private void DoorOpen()
    {
        if (goOpen == true)
        {
            if (door.transform.position.y <= 4)
            {
                
                door.transform.Translate(0, 4 * (Time.deltaTime * doorOpenSpeed), 0);
            }
    
        }
        
    }
}
