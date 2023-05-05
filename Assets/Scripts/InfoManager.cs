using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class InfoManager : MonoBehaviour
{
    public GameObject infoUI;
    public TMP_Text infoText;
    public GameObject player;



    IEnumerator ShowInfo(string message, float delay)
    {
        infoText.text = message;

        yield return new WaitForSeconds(delay);
        infoText.text = null;
        infoUI.SetActive(false);
    }
    public void ShowInfo(string sentences)
    {
        infoUI.SetActive(true);
        StartCoroutine(ShowInfo(sentences, 3.5f));
        
        //infoText.text=sentences;

    }

}
