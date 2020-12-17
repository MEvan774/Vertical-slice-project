using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Events;

public class EnemyPath : MonoBehaviour
{
    public Transform[] wayPoints;
    public Transform player;
    public float aggroRange;
    bool isHiding = false;
    public EnemyHealth health;
    public HitDetection hitDetect;

    public Animator anim;

    public int currentPoint;
    private int endPoint;
    private bool atDestination;

    public float minDistance;
    public float speed;

    bool isTurning = false;

    //public UnityEvent attackEvent;

    private Vector3 beginPos;

    private void Start()
    {
        endPoint = wayPoints.Length;
        beginPos = transform.position;
        //wayPoints = wayPointArray;
    }

    // Update is called once per frame
    void Update()
    {

        float distToPlayer = Vector2.Distance(transform.position, player.position);
        if (distToPlayer <= aggroRange)//Checkt of player te dicht bij is.
        {
            Debug.Log("Hiding");
            isHiding = true;
            health.isInvulnerable = true;
            hitDetect.hitOn = false;
            anim.SetBool("Hide", true);
        }
        else// if(distToPlayer >= maxAggroRange)//Checkt als player op afstand is, hij valt dan aan!
        {
            if (isHiding)
            {
                anim.SetBool("Hide", false);
            }
            if (!isHiding)
            {
                walking();
            }
        }

    }

    void walking()
    {
        if (currentPoint == endPoint)
        {
            ResetArray();
        }
        if (!atDestination)
        {
            float distance = Vector3.Distance(gameObject.transform.position, wayPoints[currentPoint].transform.position);
            if (distance > minDistance)
            {
                //Debug.Log("destination");
                //gameObject.transform.LookAt(wayPoints[currentPoint].transform.position);
                if (!isTurning)
                {
                    transform.position = Vector2.MoveTowards(transform.position, wayPoints[currentPoint].transform.position, speed * Time.deltaTime);
                    gameObject.transform.position += gameObject.transform.forward * speed * Time.deltaTime;
                }
            }
            else
            {
                isTurning = true;
                Vector3 theScale = transform.localScale;
                theScale.x *= -1;
                transform.localScale = theScale;
                anim.SetTrigger("Turn");


                //transform.LookAt(transform.position + wayPoints[currentPoint].forward);

                //Debug.Log("ELSE");
                Debug.Log(wayPoints[currentPoint]);
                currentPoint++;
            }
        }
    }

    void HideOutEvent()
    {
        isHiding = false;
        health.isInvulnerable = false;
        hitDetect.hitOn = true;
        Debug.LogWarning("HideOut");
    }

    public void TurnEvent()
    {
        isTurning = false;
    }

    void ResetArray()
    {
        currentPoint = 0;
        //gameObject.transform.position = beginPos;
    }
}
