using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour {

	public CharacterController2D controller;

	Rigidbody2D rb;

	[SerializeField] private float runSpeed = 40f;

	float movementY = 0f;

	bool jump = false;

	bool crouch = false;
	
	IEnumerator dashCoroutine;
	bool isDashing;
	bool canDash = true;
	float direction = 1;
	float normalGravity;

	void Start()
	{
		rb = GetComponent<Rigidbody2D>();
		normalGravity = rb.gravityScale;
	}
	
	
	void Update () {

		 movementY = Input.GetAxisRaw("Horizontal") * runSpeed; //links, rechts lopen 

		if (Input.GetButtonDown("Jump")) //button aangemaakt voor de characterController 2D
		{
			jump = true;
		}

		if (Input.GetButtonDown("Crouch")) //button aangemaakt voor de characterController 2D
		{
			crouch = true;
		} else if (Input.GetButtonUp("Crouch")) //button aangemaakt voor de characterController 2D
		{
			crouch = false;
		}
		
	  
		if (Input.GetKeyDown(KeyCode.LeftShift) && canDash == true)
		{
			dashCoroutine = Dash(.1f,5);
			StartCoroutine(dashCoroutine);
			
			if (dashCoroutine != null)
			{
				StopCoroutine(dashCoroutine);
			}
			dashCoroutine = Dash(.1f, 1);
			StartCoroutine(dashCoroutine);
		}

		if (movementY != 0)
		{
			direction = movementY;
		}

	}

	void FixedUpdate ()
	{
		//beweeg de player
		controller.Move(movementY * Time.fixedDeltaTime, crouch, jump);
		jump = false;

		if (isDashing)
		{
			rb.AddForce(new Vector2(direction * 0.5f,0), ForceMode2D.Impulse);
		}
	}

	IEnumerator Dash(float dashDuration, float dashCooldown)
	{
		Vector2 originalVelocity = rb.velocity;
		isDashing = true;
		canDash = false;
		rb.gravityScale = 0;
		rb.velocity = originalVelocity;
		yield return new WaitForSeconds(dashDuration);
		
		isDashing = false;
		rb.gravityScale = normalGravity;
		rb.velocity = originalVelocity;
		
		yield return new WaitForSeconds(dashCooldown);
		canDash = true;
	}
}