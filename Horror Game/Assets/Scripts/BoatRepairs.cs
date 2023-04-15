using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BoatRepairs : MonoBehaviour
{
    GameManager gameManager;

    public bool hasGas;
    public bool hasCompass;
    public bool hasEngine;
    public string winSceneToLoad;


    public GameObject engineOnBoat;
    public Animator boatPropellerAnimator;
    public AudioSource boatEngineSource;
    public AudioClip boatEngineSoundClip;

    private void Start() {
        gameManager = GameManager.instance;
    }   

    private void OnTriggerEnter(Collider other)
    {
        switch(other.tag){
            case "Gas":
            
                hasGas = true;
                Destroy(other.gameObject);
                boatPropellerAnimator.enabled = true;
                boatEngineSource.PlayOneShot(boatEngineSoundClip);
                Debug.Log("Gas Can Ran into Boat Trigger");
            break;
            case "Compass":
                hasCompass = true;
                Destroy(other.gameObject);
                Debug.Log("Compass Ran Into Boat Trigger");
            break;
            case "Engine":
                hasEngine = true;
                Destroy(other.gameObject);
                engineOnBoat.SetActive(true);
                Debug.Log("Engine Ran into Boat Trigger");
            break;
            case "Player":
                gameManager.CompleteTask("escape");
            break;
        }
        

        if (hasGas && hasCompass && hasEngine) {
            //SceneManager.LoadScene(winSceneToLoad);
            if( gameManager.CompleteTask("boat"))
            {

            }
        }

    }
}
