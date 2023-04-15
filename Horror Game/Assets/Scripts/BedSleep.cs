using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BedSleep : MonoBehaviour
{
    GameManager gameManager;
    AudioSource audioSource;
    public AudioManager audioManager;
    public AudioClip nightMusic;

    private void Start() {
        gameManager = GameManager.instance;
        audioManager = GameObject.FindGameObjectWithTag("Audio Manager").GetComponent<AudioManager>();
    }

    //public string sceneNameToLoad;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player")) {

            Debug.Log("Bed Trigger Entered");
            //SceneManager.LoadScene(sceneNameToLoad);

            if(gameManager.CompleteTask("sleep1"))
            {
                gameManager.TransitionState("NightTime");
                //Add audio clip switching for background music in audio manager
                audioManager.ChangeAudio(audioManager.nightMusic);
            }
        }
        
    }
}
