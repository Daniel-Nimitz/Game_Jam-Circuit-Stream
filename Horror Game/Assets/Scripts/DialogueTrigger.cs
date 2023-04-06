using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DialogueTrigger : MonoBehaviour
{
    public TMP_Text dialogueText;

    public string[] dialogueToSay;

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("collision happened with trigger");
        dialogueText.gameObject.SetActive(true);
        dialogueText.text = dialogueToSay[0];
        foreach(string i in dialogueToSay){ 
        
        }
    }

}
