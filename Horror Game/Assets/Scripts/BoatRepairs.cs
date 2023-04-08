using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BoatRepairs : MonoBehaviour
{

    public bool hasGas;
    public bool hasCompass;
    public bool hasEngine;
    public string winSceneToLoad;


    public GameObject engineOnBoat;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Gas"))
        {
            hasGas = true;
            Debug.Log("Gas Can Ran into Boat Trigger");
        }
        if (other.CompareTag("Compass")) {
            hasCompass = true;
            Debug.Log("Compass Ran Into Boat Trigger");
        }
        if(other.CompareTag("Engine")) {
            hasEngine = true;
            engineOnBoat.SetActive(true);
            Debug.Log("Engine Ran into Boat Trigger");

        }
        

        if (hasGas && hasCompass && hasEngine) {
            SceneManager.LoadScene(winSceneToLoad);
        }

    }
}
