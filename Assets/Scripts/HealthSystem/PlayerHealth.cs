using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : HealthParent
{
    [Header("Player HP Text")]
    public Text playerHealth;

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
        //Player Hit animatie
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
