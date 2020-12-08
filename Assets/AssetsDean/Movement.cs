using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour {

	public CharacterController2D controller;
	public Animator anim;

	public float runSpeed = 40f;

	float horizontalMove = 0f;

	bool jump = false;

	bool crouch = false;

	bool lockMovement;
	
	// Update is called once per frame
	void Update () {

		horizontalMove = Input.GetAxisRaw("Horizontal") * runSpeed;

		if (Input.GetButton("Horizontal"))
        {
			anim.SetBool("Move", true);
		}
        else
        {
			anim.SetBool("Move", false);
		}

		if (Input.GetButtonDown("Jump"))
		{
			jump = true;
		}

		if (Input.GetButtonDown("Crouch"))
		{
			//Debug.LogError("Fucking crouchs");
			crouch = true;
		} else if (Input.GetButtonUp("Crouch"))
		{
			crouch = false;
		}

	}

	void FixedUpdate ()
	{
		// Move our character
		if(!lockMovement)
		controller.Move(horizontalMove * Time.fixedDeltaTime, crouch, jump);
		else
		controller.Move(0, crouch, jump);

		jump = false;
	}

	public void LockMovementEvent()
    {
		lockMovement = true;
    }

	public void DelockMovementEvent()
    {
		lockMovement = false;
    }
}