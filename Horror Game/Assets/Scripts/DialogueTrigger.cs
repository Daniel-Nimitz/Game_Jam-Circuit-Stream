using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DialogueTrigger : MonoBehaviour
{
    public GameObject playerCharacter;



    public TMP_Text dialogueText;

    public string[] dialogueToSay;

    private float distanceToPlayer;

    public float startingDialogueDistance = 40;


    private void Awake()
    {
        playerCharacter = GameObject.FindWithTag("Player");
    }


    private void Update()
    {
        distanceToPlayer = Vector3.Distance(this.gameObject.transform.position, playerCharacter.transform.position);
        if (distanceToPlayer <  startingDialogueDistance) {
            dialogueText.gameObject.SetActive(true);
            dialogueText.text = dialogueToSay[0];
        }
    }

    
    



    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("collision happened with trigger");
        dialogueText.gameObject.SetActive(true);
        dialogueText.text = dialogueToSay[0];
        
    }
    //Use coroutines to say each text one at a time
    //Make if statement to check only for player
}
