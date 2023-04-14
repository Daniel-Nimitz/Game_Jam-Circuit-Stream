using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//a all purpose quick and nasty trigger script used to complete tasks

public class PlayerTaskTrigger : MonoBehaviour
{
    GameManager gameManager = GameManager.instance;
    public int taskID;

    void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player")){
            gameManager.CompleteTask(taskID);
        }
    }
}
