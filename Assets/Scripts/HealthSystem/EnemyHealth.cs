using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : HealthParent
{
    public bool isInvulnerable;

    public override void TakeDamage(int damage)
    {
        if (!isInvulnerable)
        {
            //Sprite wit maken met shader?

            base.TakeDamage(damage);
        }
    }

    protected override void Die()
    {
        //Instantiate deatheffect
        base.Die();
        Debug.Log("EnemyKilled");
    }
}
