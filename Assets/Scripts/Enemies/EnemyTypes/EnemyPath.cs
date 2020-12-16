using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Events;

public class EnemyPath : MonoBehaviour
{
    public Transform[] wayPoints;


    public int currentPoint;
    private int endPoint;
    private bool atDestination;

    public float minDistance;
    public float speed;

    public Animator anim;
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
