using UnityEngine;

public class GameManager : MonoBehaviour
{
    public TextAsset taskRawXmlFile; //the XML file used to add tasks

    public static GameManager instance {get; private set;}//an instance of this class
    
    public Material nightSkyboxMaterial; //the material used to turn the sky into night
    TaskManager _taskManager;// a reference to the task manager class 
    
    private void Awake() {
        if(instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
    
    void Start()
    {
        _taskManager = new TaskManager(taskRawXmlFile);
    }

    public GameManager getInstance(){
        if(instance != this)
            instance = this;
        return instance;
    }

    //completes the current task if valid
    //if valid returns true otherwise returns false
    public bool CompleteTask(int index){
        if(_taskManager.IsAllTasksCompleted()){
            Debug.Log("YOU WIN!!!!!");
        }

        if(_taskManager.GetCurrentTask().index == index){
            _taskManager.CompleteCurrentTask();
            return true;
        }
        return false;
    }

    //use a tag, I recommend this one!
    public bool CompleteTask(string tag){
        if(_taskManager.IsAllTasksCompleted()){
            Debug.Log("YOU WIN!!!!!");
        }

        if(_taskManager.GetCurrentTask().tag.Equals(tag)){
            _taskManager.CompleteCurrentTask();
            return true;
        }
        return false;
    }

    //used to switch between night and day
    public void TransitionState(string state){
        Transform stateObj = GameObject.Find("States").transform;

        Transform s = stateObj.Find(state);
        //guard clause to prevent null exception errors if the given state arg is invalid
        if(s == null)
            return;

        //set all children inactive
        foreach(Transform child in stateObj){
            child.gameObject.SetActive(false);
        }

        //set the desired state gameobject to active
        s.gameObject.SetActive(true);

        //a special clause to turn the skybox into the nighttime skybox
        if(state == "NightTime")
            RenderSettings.skybox = nightSkyboxMaterial;

    }

    public void TeleportPlayer(Transform transform)
    {
        GameObject.FindWithTag("Player").transform.position = transform.position;
    }
}
