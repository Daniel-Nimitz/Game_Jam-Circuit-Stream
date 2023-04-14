using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class TaskManager
{
    //public instance to be used by other scripts
    public static TaskManager instance; //in instance of this object
    public Task currentTask; //the current task the player should be working towards
    private List<Task> _tasks = new List<Task>();  //the list of tasks to keep track of
    private int _taskIndex = 0; //used to iterate through the tasks in "GetNextTask" method

    public TaskManager(TextAsset file)
    {
        if(instance == null || instance != this)
            instance = this;
        
        //initiate and populate the tasks
        XMLdata[] data = XmlLoader.parseXmlFile(file);
        for(int i = 0; i < data.Length; i++)
        {
            XMLdata d = data[i];
            _tasks.Add(new Task(d.title, d.tag, i));
        }

        currentTask = _tasks[_taskIndex];
        //PrintAllTasks();
    }

    //iterates through tasks
    public Task GetNextTask()
    {
        if(_taskIndex >= _tasks.Count)
            _taskIndex = 0;
        else
            _taskIndex++;

        return _tasks[_taskIndex];
    }

    //returns the current task the player is working towards
    public Task GetCurrentTask(){
        if(currentTask == null){
            Debug.LogWarning("Could not get current task as none was set");
            return null;
        }

        return currentTask;
    }

    //completes the current task and changes it to the next task in the list
    public void CompleteCurrentTask()
    {
        currentTask.isComplete = true;
        currentTask = GetNextTask();
    }

    //returns true if all tasks have been completed else return false
    public bool IsAllTasksCompleted(){
        foreach(Task t in _tasks){
            if(!t.isComplete)
                return false;
        }
        return true;
    }

    //prints all tasks in the list, used for debugging
    void PrintAllTasks()
    {
        foreach(Task t in _tasks)
        {
            Debug.Log($"{t.title} with tag: {t.tag}");
        }
    }
}

//task object
public class Task{

    public int index = -1; 
    public bool isComplete;
    public string title, tag;

    public Task(string title, string tag, int index){
        this.title = title;
        isComplete = false;
        this.tag = tag;
    }
}
