using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Respawn : MonoBehaviour
{
    public int _Respawn;

    void OnTriggerEnter2D(Collider2D other)
    {
            //Debug.Log(other.name);
            PlayerHealth player = other.GetComponent<PlayerHealth>();
            if (player != null)
            {
                player.TakeDamage(3);
            }
    }


}
