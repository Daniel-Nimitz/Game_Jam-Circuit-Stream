using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TaskManager
{
    //public instance to be used by other scripts
    public static TaskManager instance;

    //the list of tasks to keep track of
    private List<Task> _tasks = new List<Task>(); 

    public TaskManager(TextAsset file)
    {
        if(instance == null || instance != this)
            instance = this;
        
        //initiate and populate the tasks
        string[] data = XmlLoader.parseXmlFile(file);
        for(int i = 0; i < data.Length; i++)
        {
            _tasks.Add(new Task(data[i]));
        }

        //PrintAllTasks();
    }

    //get the next task in the list
    public Task GetNextActiveTask()
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

    public Task(string title, bool isActive = true){
        this.title = title;
        isComplete = false;
        this.isActive = isActive;
    }

    public void Complete()
    {
        isComplete = true;
    }
}
