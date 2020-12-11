using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour {

	public AudioManager sound;
	public CharacterController2D controller;
	public Animator anim;

	public float runSpeed = 40f;

	float horizontalMove = 0f;

	bool jump = false;

	bool crouch = false;

	bool lockMovement;

	public Rigidbody2D rb;

	public float dashDuration;
	public float dashCooldown;

	float normalGravity;

	IEnumerator dashCoroutine;
	bool isDashing;
	bool canDash = true;
	public float DashSpeed;
	private float rightDashSpeed;
	private float leftDashSpeed;

	private void Start()
    {
        normalGravity = rb.gravityScale;

		rightDashSpeed = DashSpeed;
		leftDashSpeed =- rightDashSpeed;
	}
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
			anim.SetBool("Crouch", true);
			crouch = true;
		} else if (Input.GetButtonUp("Crouch"))
		{
			anim.SetBool("Crouch", false);
			crouch = false;
		}



		if (Input.GetKeyDown(KeyCode.LeftShift) && canDash == true)
		{
			dashCoroutine = Dash(.1f, 5);
			StartCoroutine(dashCoroutine);

			if (dashCoroutine != null)
			{
				StopCoroutine(dashCoroutine);
			}
			dashCoroutine = Dash(.1f, 1);
			StartCoroutine(dashCoroutine);
		}

	}

	IEnumerator Dash(float dashDuration, float dashCooldown)
	{
		anim.SetTrigger("Dash");
		sound.play("playerDash");
		Debug.Log("DAshing.."); 
		Vector2 originalVelocity = rb.velocity;
		isDashing = true;
		canDash = false;
		rb.gravityScale = 0;
		rb.velocity = originalVelocity;
		yield return new WaitForSeconds(dashDuration);

		isDashing = false;
		rb.gravityScale = normalGravity;
		rb.velocity = originalVelocity;
		Debug.Log("Cooldown...");
		yield return new WaitForSeconds(dashCooldown);
		canDash = true;
	}

	void FixedUpdate ()
	{
		// Move our character
		if(!lockMovement)
		controller.Move(horizontalMove * Time.fixedDeltaTime, crouch, jump);
		else
		controller.Move(0, crouch, jump);

		jump = false;

		if (isDashing)
		{
			rb.AddForce(new Vector2(DashSpeed * 0.5f, 0), ForceMode2D.Impulse);
		}
	}


	private void OnTriggerEnter2D(Collider2D other)
	{
		if (other.gameObject.CompareTag("Coin"))
		{
			Destroy(other.gameObject);
		}
	}

	public void TurnLeftEvent()
    {
		DashSpeed = leftDashSpeed;
    }

	public void TurnRightEvent()
	{
		DashSpeed = rightDashSpeed;
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