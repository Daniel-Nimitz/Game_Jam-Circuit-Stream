using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BedSleep : MonoBehaviour
{

    public string sceneNameToLoad;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player")) {

            Debug.Log("Bed Trigger Entered");
            SceneManager.LoadScene(sceneNameToLoad);
        }
        
    }
}
