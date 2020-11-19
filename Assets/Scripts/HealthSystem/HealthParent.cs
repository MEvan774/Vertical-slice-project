using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthParent : MonoBehaviour
{
    public int maxHp;
    protected int currentHp;

    protected virtual void Start()
    {
        currentHp = maxHp;
    }

    public virtual void TakeDamage(int damage)
    {
        currentHp -= damage;
        if (currentHp <= 0)
        {
            Die();
        }
    }

    protected virtual void Die()
    {
        Destroy(gameObject);
    }
}
