using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPaddoBehavior : MonoBehaviour
{
    Transform player;
    public float aggroRange;
    bool isHiding;

    public float firerate;

    public Transform firePoint;
    public GameObject ProjectilePrefab;



    // Start is called before the first frame update
    void Start()
    {
        isHiding = true;
    }

    // Update is called once per frame
    void Update()
    {
        EnemyIdle();

        float distToPlayer = Vector2.Distance(transform.position, player.position);
        if(distToPlayer <= aggroRange)
        {
            EnemyStateToAttack();
        }
        else
        {
            EnemyStateToHide();
        }
    }

    void EnemyIdle()
    {
        if (!isHiding)
        {
            ShootFunction();
        }
    }

    void EnemyStateToAttack()
    {
        isHiding = false;
    }

    void EnemyStateToHide()
    {
        isHiding = true;
    }

    void ShootFunction()
    {
        //shoot with fireRate
    }

    void AttackAnimEvent()
    {
        GameObject bullet = Instantiate(ProjectilePrefab, firePoint.position, player.rotation);
    }
}

