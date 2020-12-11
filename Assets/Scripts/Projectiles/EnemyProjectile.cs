using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyProjectile : ProjectileParent
{
    public bool parryAble;
    private GameObject target;
    private Vector2 direction;

    protected override void Start()
    {
        //screenBounds = Camera.main.ScreenToViewportPoint(new Vector3(Screen.width, Screen.height, Camera.main.transform.position.z));

        //Zoekt "Player" Tag en gaat op de player af 
        target = GameObject.FindGameObjectWithTag("Player");
        direction = (target.transform.position - transform.position).normalized * speed;
        rb.velocity = new Vector2(direction.x, direction.y);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        //Debug.Log(other.name);
        PlayerHealth player = other.GetComponent<PlayerHealth>();
        //EnemyHealth parry = other.GetComponent<playerParry>();
        if (player != null)
        {
            player.TakeDamage(damage);
            DestroyBullet();
        }

        //!--Voor Parry--!
        /*
        else if(parryAble && parry != null)
        {
            //Give Point
            DestroyBullet();
        }
        */

    }
}
