using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

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
    public bool stopMovement = false;
    public bool direction = false;//Checkt als player links of rechts is
    private bool GroundCheck;

    public UnityEvent lockInPlace;
    public UnityEvent deLockPlace;

    void Update()
    {
        if (Input.GetKey("c"))
        {
            stopMovement = true;
            lockInPlace.Invoke();
            Debug.Log("C is pressed");
            //Activate Event voor movement
        }
        else
        {
            stopMovement = false;
            deLockPlace.Invoke();
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

    public void Left()
    {
        direction = true;
    }

    public void Right()
    {
        direction = false;
    }

    public void GroundEvent()
    {

    }

}
