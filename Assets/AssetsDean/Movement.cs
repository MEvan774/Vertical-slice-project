﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour {

	public CharacterController2D controller;

	public float runSpeed = 40f;

	float horizontalMove = 0f;

	bool jump = false;

	bool crouch = false;

	bool lockMovement;
	
	// Update is called once per frame
	void Update () {

		horizontalMove = Input.GetAxisRaw("Horizontal") * runSpeed;

		if (Input.GetButtonDown("Jump"))
		{
			jump = true;
		}

		if (Input.GetButtonDown("Crouch"))
		{
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