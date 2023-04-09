using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;
using TMPro;

public class Talker : MonoBehaviour
{
    Camera follow;

    GameObject canvasGO;
    Canvas canvas;

    [SerializeField] TMP_Text textprefab;
    TMP_Text text;

    SphereCollider trigger;
    [SerializeField] float radius = 10;
    [SerializeField] float offset = 3;


    [SerializeField] string[] dialogue;
    int index = -1;

    void CycleDialogue()
    {
        index += 1;

        if (index >= dialogue.Length)
            index = 0;

        text.SetText(dialogue[index]);
    }

    void Talking(bool active)
    {
        if (active)
        {
            canvas.gameObject.SetActive(true);
            CycleDialogue();
			InvokeRepeating("CycleDialogue", 3f, 3f);
        }
        else
        {
            canvas.gameObject.SetActive(false);
            CancelInvoke();
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Talking(true);
        }
    }

	void OnTriggerStay(Collider other)
	{
	    if(other.gameObject.CompareTag("Player"))	
            transform.LookAt(new Vector3(other.transform.position.x,transform.position.y,other.transform.position.z));
	}

	void OnTriggerExit(Collider other)
    {
        Talking(false);
    }

    // Start is called before the first frame update
    void Start()
    {
        follow = FindObjectOfType<Camera>();

        //add collider, set it to trigger, set the radius
        trigger = this.AddComponent<SphereCollider>();
        trigger.isTrigger = true;
        trigger.radius = radius;

        //create the canvas with the right settings
        canvasGO = new GameObject("Dialogue", typeof(Canvas), typeof(GraphicRaycaster));
        canvas = canvasGO.GetComponent<Canvas>();
        canvas.renderMode = RenderMode.WorldSpace;
        canvas.worldCamera = follow;
        canvas.GetComponent<RectTransform>().sizeDelta = new Vector2(5, 3);
        canvasGO.transform.SetParent(transform, false);
        Vector3 temppos=canvasGO.transform.localPosition;
        Vector3 temprot = canvasGO.transform.localEulerAngles;
        temppos.y += offset;
        temprot.y += 180;
        canvasGO.transform.localPosition = temppos;
        canvasGO.transform.localEulerAngles = temprot;

        //I gave up on making the text work through code, there's just a prefab now haha
        text=Instantiate(textprefab, canvas.transform);
        canvas.gameObject.SetActive(false);
	}
}
