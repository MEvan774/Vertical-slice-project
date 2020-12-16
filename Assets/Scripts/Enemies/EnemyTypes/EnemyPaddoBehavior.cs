using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPaddoBehavior : MonoBehaviour
{
    public Transform player;
    public float minAggroRange;
    public float maxAggroRange;

    public Animator anim;

    [SerializeField]
    private bool isHiding = true;
    private EnemyHealth health;

    public float fireRate;
    private float nextTimeToFire;

    public Transform firePoint;
    public GameObject projectilePrefab;


    // Start is called before the first frame update
    void Start()
    {
        isHiding = true;

        health = gameObject.GetComponent<EnemyHealth>();
    }

    // Update is called once per frame
    void Update()
    {

        float distToPlayer = Vector2.Distance(transform.position, player.position);
        if(distToPlayer <= minAggroRange)//Checkt of player te dicht bij is.
        {
            isHiding = true;
            health.isInvulnerable = true;
        }
        else// if(distToPlayer >= maxAggroRange)//Checkt als player op afstand is, hij valt dan aan!
        {
            isHiding = false;
            health.isInvulnerable = false;
            ShootFunction();
        }
    }

    void ShootEvent()
    {
        GameObject bullet = Instantiate(projectilePrefab, firePoint.position, firePoint.rotation);
    }

    void ShootFunction()
    {
        if(Time.time >= nextTimeToFire)//FireRate
        {
            nextTimeToFire = Time.time + 1f / fireRate;
            anim.SetTrigger("Attack");
        }
    }
}

