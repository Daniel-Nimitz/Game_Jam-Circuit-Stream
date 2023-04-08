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

    public int dialogueIndex;


    private void Awake()
    {
        playerCharacter = GameObject.FindWithTag("Player");
    }


    private void Update()
    {
        distanceToPlayer = Vector3.Distance(this.gameObject.transform.position, playerCharacter.transform.position);
        CheckDialogueStatus();

        //if (dialogueIndex <= dialogueToSay.Length) {
        //    dialogueIndex++;
         //   CheckDialogueStatus();
        //}
    }

    private void CheckDialogueStatus()
    {
        if (distanceToPlayer < startingDialogueDistance)
        {
            dialogueText.text = dialogueToSay[dialogueIndex];
            dialogueText.gameObject.SetActive(true);

        }
        if (distanceToPlayer > startingDialogueDistance)
        {
            dialogueText.gameObject.SetActive(false);
            dialogueText.text = dialogueToSay[0];
        }
    }

    
    
    //IEnumerator NextDialogue() {
        //if (dialogueToSay[dialogueIndex] == null) {
        //return;

        //}
        //CheckDialogueStatus();
      //  yield return new WaitForSeconds(3f);
        //dialogueIndex++;
    //}
    //Use coroutines to say each text one at a time


    //Rotate the text

}
