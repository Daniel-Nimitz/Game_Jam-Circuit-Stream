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
    public Animator boatPropellerAnimator;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Gas"))
        {
            hasGas = true;
            Destroy(other.gameObject);
            boatPropellerAnimator.enabled = true;
            Debug.Log("Gas Can Ran into Boat Trigger");
        }
        if (other.CompareTag("Compass")) {
            hasCompass = true;
            Destroy(other.gameObject);
            Debug.Log("Compass Ran Into Boat Trigger");
        }
        if(other.CompareTag("Engine")) {
            hasEngine = true;
            Destroy(other.gameObject);
            engineOnBoat.SetActive(true);
            Debug.Log("Engine Ran into Boat Trigger");

        }
        

        if (hasGas && hasCompass && hasEngine) {
            SceneManager.LoadScene(winSceneToLoad);
        }

    }
}
