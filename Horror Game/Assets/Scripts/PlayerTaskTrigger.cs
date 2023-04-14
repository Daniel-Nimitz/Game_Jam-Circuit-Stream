using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//a all purpose quick and nasty trigger script used to complete tasks

public class PlayerTaskTrigger : MonoBehaviour
{
    GameManager gameManager = GameManager.instance;

    public bool useIndex = false;
    public string taskTag;
    public int taskIndex;

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
