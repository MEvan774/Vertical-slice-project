using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerProjectile : ProjectileParent
{
    void OnTriggerEnter2D(Collider2D other)
    {
        //Debug.Log(other.name);
        EnemyHealth enemy = other.GetComponent<EnemyHealth>();
        if (enemy != null)
        {
            Debug.Log("BulletDestroy");
            enemy.TakeDamage(damage);
            DestroyBullet();
        }
    }
}
