using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootScript : MonoBehaviour
{
    public GameObject ProjectilePrefab;
    public Transform firePoint;//punt waaruit de bullet komt

    //FireRate
    public float fireRate;
    private float nextTimeToFire;
    public float projectileSpeed;

    public Quaternion rotatePos = new Quaternion(90, 0, 0 ,0);

    //movement
    bool stopMovement = false;

    bool direction = false;//Checkt als player links of rechts is

    void Update()
    {
        if (Input.GetKey("z"))
        {
            stopMovement = true;
            Debug.Log("Z is pressed");
            //Activate Event voor movement
        }
        else
        {
            stopMovement = false;
        }

        if (Input.GetMouseButton(0) && Time.time >= nextTimeToFire)
        {
            nextTimeToFire = Time.time + 1f / fireRate;
            Shoot();
        }
    }

    void Shoot()
    {
        if (stopMovement)
        {
            if (Input.GetKey("d") && !Input.GetKey("w"))//Rechts
                rotatePos = new Quaternion(0, 0, 0, 0);

            if (Input.GetKey("d") && Input.GetKey("w"))//RechtsBoven
                rotatePos = new Quaternion(180, 90, 0, 0);

            if (Input.GetKey("w") && !Input.GetKey("a") && !Input.GetKey("d"))//Boven
                rotatePos = new Quaternion(90, 90, 0, 0);

            if (Input.GetKey("a") && Input.GetKey("w"))//LinksBoven
                rotatePos = new Quaternion(180, 320, 0, 0);

            if (Input.GetKey("a") && !Input.GetKey("w"))//links
                rotatePos = new Quaternion(0, 320, 0, 0);
        }
        else//Checkt welk richting player staat
        {
            if(!direction)
            rotatePos = new Quaternion(0, 0, 0, 0);//Rechts
            else
            rotatePos = new Quaternion(0, 320, 0, 0);//Links

        }
        GameObject bullet = Instantiate(ProjectilePrefab, firePoint.position, rotatePos);
    }

    /*!--Events om schiet richting links of rechts te zetten--!*/
    public void MoveRightEvent()
    {
        direction = false;
    }

    public void MoveLeftEvent()
    {
        direction = true;
    }
}
