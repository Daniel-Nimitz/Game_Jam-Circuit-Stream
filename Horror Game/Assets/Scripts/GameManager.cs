using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public TextAsset taskRawXmlFile;

    TaskManager _taskManager;
    // Start is called before the first frame update
    void Start()
    {
        _taskManager = new TaskManager(taskRawXmlFile);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
