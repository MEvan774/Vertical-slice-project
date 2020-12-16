using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : HealthParent
{
    public bool isInvulnerable;

    private Renderer render;

    private Color hitColor = Color.red;

    private Color normalColor = Color.white;

    private float hitDuration = 0.1f;

    public GameObject DeathEffect;

    private void Awake()
    {
        render = GetComponent<Renderer>();
    }

    public override void TakeDamage(int damage)
    {
        if (!isInvulnerable)
        {
            //Sprite wit maken met shader?

            base.TakeDamage(damage);
            StartCoroutine(HitFlash());
        }
    }

    IEnumerator HitFlash()
    {
        render.material.color = hitColor;
        yield return new WaitForSeconds(hitDuration);
        render.material.color = normalColor;
    }

    protected override void Die()
    {
        GameObject effect = Instantiate(DeathEffect, transform.position, transform.rotation);
        base.Die();
        Debug.Log("EnemyKilled");
    }
}
