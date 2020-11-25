using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFlower : MonoBehaviour
{
    public Transform player;
    public float aggroRange;

    public float fireRate;
    private float nextTimeToFire;

    public Transform firePoint;
    public GameObject projectilePrefab;

    void Update()
    {

        float distToPlayer = Vector2.Distance(transform.position, player.position);
        if (distToPlayer <= aggroRange)//Checkt of player te dicht bij is.
        {
            ShootFunction();
        }
    }

    void ShootFunction()
    {
        if (Time.time >= nextTimeToFire)//FireRate
        {
            nextTimeToFire = Time.time + 1f / fireRate;
            Shoot();
        }
    }

    void Shoot()
    {
        GameObject bullet = Instantiate(projectilePrefab, firePoint.position, firePoint.rotation);
    }
}
