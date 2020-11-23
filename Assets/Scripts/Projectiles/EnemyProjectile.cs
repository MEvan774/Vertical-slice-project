using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyProjectile : ProjectileParent
{
    public bool parryAble;

    void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log(other.name);
        PlayerHealth player = other.GetComponent<PlayerHealth>();
        //EnemyHealth parry = other.GetComponent<playerParry>();
        if (player != null)
        {
            player.TakeDamage(damage);
            DestroyBullet();
        }
        /*
        else if(parryAble && parry != null)
        {
            //Give Point
            DestroyBullet();
        }
        */

    }
}
