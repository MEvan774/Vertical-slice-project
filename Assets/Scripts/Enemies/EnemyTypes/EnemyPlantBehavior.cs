﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPlantBehavior : MonoBehaviour
{
    public Animator anim;

    public float jumpTimer;

    public float JumpSpeed;
    public float JumpLenght;

    private bool isJumping = false;
    private bool jumpReturn;

    public Rigidbody2D EnemyRB;

    private Vector2 originalPos;
    //public Vector2 endPos = new Vector2(0,0);
    public Transform endPos;

    void Start()
    {
        originalPos = transform.localPosition;
        StartCoroutine(Jump());
    }

    // Update is called once per frame
    void FixedUpdate()
    {

        if(isJumping)
        {
            //Debug.Log("JUMPDRAG");
            JumpDrag();
        }
        else
        {
            transform.localPosition = originalPos;
            EnemyRB.velocity = new Vector2(0, 0);
            //StartCoroutine(Jump());
        }
    }

    

    IEnumerator Jump()
    {
        anim.SetTrigger("Reset");
        //Debug.Log("Enemy is Jumping");
        //transform.localPosition = new Vector2(0, JumpLenght);
        isJumping = true;

        jumpReturn = false;
        yield return new WaitForSeconds(JumpLenght);
        anim.SetTrigger("ReadyToBite");
        jumpReturn = true;
        anim.SetTrigger("Bite");
        yield return new WaitForSeconds(JumpLenght * 2);

        isJumping = false;
        jumpReturn = false;

        Debug.Log("Enemy jump ended");
        yield return new WaitForSeconds(jumpTimer);
        StartCoroutine(Jump());
    }

    void JumpDrag()
    {
        if (!jumpReturn)
        EnemyRB.AddForce(new Vector2(0, JumpSpeed * Time.fixedDeltaTime), ForceMode2D.Force);

        if (jumpReturn)
            EnemyRB.AddForce(new Vector2(0, -JumpSpeed * 2 * Time.fixedDeltaTime), ForceMode2D.Force);
    }
}
