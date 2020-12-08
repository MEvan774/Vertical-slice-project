using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PlayerHealth : HealthParent
{
    [Header("Player HP Text")]
    public TMP_Text playerHealth;

    public float invulnerableTime;
    public bool isInvulnerable = false;

    protected override void Start()
    {
        base.Start();
        playerHealth.text = "HP. " + currentHp.ToString();
    }

    //Debug function
    private void Update()
    {
        //Debug.Log(currentHp);
        if (Input.GetKeyDown("g"))
        {
            TakeDamage(1);
        }
    }


    public override void TakeDamage(int damage)
    {
        /*Maakt player onstervelijk na een hit*/
        if (!isInvulnerable)
        {
            Debug.Log("DAMAGE");
            isInvulnerable = true;
            base.TakeDamage(damage);
            StartCoroutine(InvulnerableState());
        }

        if(currentHp > 0)
        playerHealth.text = "HP. " + currentHp.ToString();
        else
        playerHealth.text = "DEAD";
    }

    IEnumerator InvulnerableState()
    {
        Debug.Log("STARTTIME");
        yield return new WaitForSeconds(invulnerableTime);
        isInvulnerable = false;
        Debug.Log("TimeUp");
    }

    protected override void Die()
    {
        //Activate GameOver

        base.Die();
        Debug.Log("PlayerKilled");
    }
}
