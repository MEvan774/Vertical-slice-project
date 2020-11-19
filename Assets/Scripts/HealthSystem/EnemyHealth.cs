using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : HealthParent
{
    public override void TakeDamage(int damage)
    {
        //Sprite wit maken met shader?

        base.TakeDamage(damage);
    }

    protected override void Die()
    {
        //Instantiate deatheffect
        base.Die();
        Debug.Log("EnemyKilled");
    }
}
