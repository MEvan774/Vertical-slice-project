using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.Events;

public class PlayerHealth : HealthParent
{
    public AudioManager sound;
    [Header("Player HP Text")]
    public TMP_Text playerHealth;

    public ScreenShake shake;

    public float invulnerableTime;
    public bool isInvulnerable = false;

    public float flashAlpha = 0;
    public float normalAlpha = 1f;
    private float flashSpeed = 0.05f;

    public UnityEvent DieEvent;

    protected override void Start()
    {
        base.Start();
        playerHealth.text = "HP. " + currentHp.ToString();
    }

    public override void TakeDamage(int damage)
    {
        /*Maakt player onstervelijk na een hit*/
        if (!isInvulnerable)
        {
            //Debug.Log("DAMAGE");
            isInvulnerable = true;
            base.TakeDamage(damage);
            StartCoroutine(InvulnerableState());
            StartCoroutine(InvulnerableFlash());
            shake.Shake();

            if (currentHp >= 2)
            {
                sound.play("playerHitTwo");
                playerHealth.text = "HP. " + currentHp.ToString();
            }
            else if (currentHp >= 1)
            {
                sound.play("playerHitThree");
                playerHealth.text = "HP. " + currentHp.ToString();
            }
            else
            {
                playerHealth.text = "DEAD";
                DieEvent.Invoke();
            }
        }
    }

    IEnumerator InvulnerableState()
    {
        //Debug.Log("STARTTIME");
        yield return new WaitForSeconds(invulnerableTime);
        isInvulnerable = false;
        //Debug.Log("TimeUp");
    }

    IEnumerator InvulnerableFlash()
    {
        GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, flashAlpha);
        yield return new WaitForSeconds(flashSpeed);
        GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, normalAlpha);
        yield return new WaitForSeconds(flashSpeed);
        if (isInvulnerable)
        StartCoroutine(InvulnerableFlash());
    }

    protected override void Die()
    {
        //Activate GameOver
        sound.play("playerDeath");
        base.Die();
        Debug.Log("PlayerKilled");
    }
}
