using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerInventory : MonoBehaviour
{
    public List<string> inventory = new();
    public TMP_Text inventoryText;
    public GameObject endPanel;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        inventoryText = GameObject.Find("InventoryList").GetComponent<TMP_Text>();
        foreach (var item in inventory)
        {
            inventoryText.text = item;
        }
        if (inventory.Contains("End"))
        {
            endPanel.SetActive(true);
        }
    }
}
