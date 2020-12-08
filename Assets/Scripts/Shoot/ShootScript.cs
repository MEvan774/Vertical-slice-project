using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ShootScript : MonoBehaviour
{
    public GameObject ProjectilePrefab;
    public Transform firePoint;//punt waaruit de bullet komt

    //Sounds
    public AudioManager sound;

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

        if (Input.GetKey("x") && Time.time >= nextTimeToFire)
        {
            nextTimeToFire = Time.time + 1f / fireRate;
            Shoot();
        }
    }

    void Shoot()
    {
        if (stopMovement)
        {
            if (Input.GetKey(KeyCode.RightArrow) && !Input.GetKey(KeyCode.UpArrow))//Rechts
                rotatePos = new Quaternion(0, 0, 0, 0);

            if (Input.GetKey(KeyCode.RightArrow) && Input.GetKey(KeyCode.UpArrow))//RechtsBoven
                rotatePos = new Quaternion(180, 90, 0, 0);

            if (Input.GetKey(KeyCode.UpArrow) && !Input.GetKey(KeyCode.LeftArrow) && !Input.GetKey(KeyCode.RightArrow))//Boven
                rotatePos = new Quaternion(90, 90, 0, 0);

            if (Input.GetKey(KeyCode.LeftArrow) && Input.GetKey(KeyCode.UpArrow))//LinksBoven
                rotatePos = new Quaternion(180, 320, 0, 0);

            if (Input.GetKey(KeyCode.LeftArrow) && !Input.GetKey(KeyCode.UpArrow))//links
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


        sound.play("fire");
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
