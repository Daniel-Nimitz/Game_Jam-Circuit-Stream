using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TaskManager : MonoBehaviour
{
    //public instance to be used by other scripts
    public static TaskManager instance;

    private List<Task> _tasks = new List<Task>(); 

    void Start()
    {
        if(instance == null || instance != this)
            instance = this;
    }

    public Task GetNextTask()
    {
        foreach(Task t in _tasks)
        {
            if(t.isActive && !t.isComplete){
                return t;
            }
        }
        return null;
    }

//prints all tasks in the list
    void PrintAllTasks()
    {
        foreach(Task t in _tasks)
        {
            Debug.Log(t.title);
        }
    }
}

public class Task{

    public bool isActive, isComplete;

    public string title;

    public Task(string title){
        this.title = title;
    }

    public void Complete()
    {
        isComplete = true;
    }
}
