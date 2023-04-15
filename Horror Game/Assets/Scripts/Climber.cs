using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class Climber : MonoBehaviour
{
    [SerializeField] ActionBasedContinuousMoveProvider stickMover;
    [SerializeField] CharacterController character;

    [SerializeField] ActionBasedController left;
    [SerializeField] ActionBasedController right;

    [SerializeField] ActionBasedController rayL;
    [SerializeField] ActionBasedController rayR;

    [SerializeField] GrabMoveProvider grabL;
    [SerializeField] GrabMoveProvider grabR;

    [SerializeField] bool Lclimbing = false;
    [SerializeField] bool Rclimbing = false;

    Vector3 previousPosL;
    Vector3 previousPosR;

    //Rigidbody rig;

    //Start is called before the first frame update
    void Start()
    {
        grabL.enabled = false;
        grabR.enabled = false;

        //rig=GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
		if (Lclimbing || Rclimbing)
		{
			stickMover.moveSpeed=0;
            stickMover.useGravity=false;
            Climb();
            //rig.useGravity = false;
		}
		else
		{
			stickMover.moveSpeed = 5;
			stickMover.useGravity = true;
			//rig.useGravity=true;
		}
	}

    //Soooo not the greatest set up, but if it works, it works
    public void ActivateClimbingL()
    {
        Lclimbing = true;
        rayL.gameObject.SetActive(false);
        //grabL.enabled = true;
        previousPosL = left.positionAction.action.ReadValue<Vector3>();
	}
    public void DeactivateClimbingL()
    { 
        Lclimbing = false;
        rayL.gameObject.SetActive(true);
        //grabL.enabled = false;
    }
    public void ActivateClimbingR()
    {
        Rclimbing = true;
        rayR.gameObject.SetActive(false);
        //grabR.enabled = true;
        previousPosR=right.positionAction.action.ReadValue<Vector3>();
    }
    public void DeactivateClimbingR()
    {
        Rclimbing = false;
        rayR.gameObject.SetActive(true);
        //grabR.enabled = false;
    }

    void Climb()
    {
        //Check active hand velocities and add them, then move the player according to it
        Vector3 velL = new Vector3(0,0,0);
        Vector3 velR = new Vector3(0,0,0);
        
        if (Lclimbing) 
        {
			velL=(left.positionAction.action.ReadValue<Vector3>()-previousPosL)/Time.fixedTime;
		}
        
        if (Rclimbing)
        {
			velR=(right.positionAction.action.ReadValue<Vector3>()-previousPosR)/Time.fixedTime;
		}

        Vector3 vel=(velL+velR)*2;
        character.Move(transform.rotation*-vel*Time.fixedTime);

        previousPosL = left.positionAction.action.ReadValue<Vector3>();
        previousPosR = right.positionAction.action.ReadValue<Vector3>();
    }
}
