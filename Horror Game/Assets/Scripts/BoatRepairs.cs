using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BoatRepairs : MonoBehaviour
{
    public string sceneNameToLoad;
    public bool hasGas;
    public bool hasCompass;
    public bool hasLifeJacket;
    public string winSceneToLoad;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Gas"))
        {
            hasGas = true;
        }
        else if (other.CompareTag("Compass")) {
            hasCompass = true;
        }
        else if(other.CompareTag("Life Jacket")) {
            hasLifeJacket = true;
        }
        else {
            Debug.Log("Object has hit boat trigger but is not recognized as a needed boat componant.");
        }

        if (hasGas && hasCompass && hasLifeJacket) {
            SceneManager.LoadScene(winSceneToLoad);
        
        }

    }
}
