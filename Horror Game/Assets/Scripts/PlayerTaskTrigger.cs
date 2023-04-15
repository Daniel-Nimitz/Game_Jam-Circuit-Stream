using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//a all purpose quick and nasty trigger script used to complete tasks

public class PlayerTaskTrigger : MonoBehaviour
{
    GameManager gameManager;

    public bool useIndex = false;
    public string taskTag;
    public int taskIndex;

    private void Start() {
        if(gameManager == null)
            gameManager = GameManager.instance;
    }

    void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player")){
            if(useIndex)
                gameManager.CompleteTask(taskIndex);
            else
                gameManager.CompleteTask(taskTag);
        }
    }
}
