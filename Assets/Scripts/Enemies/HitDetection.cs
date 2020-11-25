using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitDetection : MonoBehaviour
{
    /*!--zet deze script op enemies of objecten(behalve projectiles) die damage doen--!*/

    private int damage = 1;

    void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log(other.name);
        PlayerHealth player = other.GetComponent<PlayerHealth>();
        if (player != null)
        {
            player.TakeDamage(damage);
        }
    }
}
