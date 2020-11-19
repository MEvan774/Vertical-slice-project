using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileScript : MonoBehaviour
{
    public float speed;
    public Rigidbody2D rb;
    private Vector2 screenBounds;

    public int damage;


    void Start()
    {
        //sets screenBounds
        screenBounds = Camera.main.ScreenToViewportPoint(new Vector3(Screen.width, Screen.height, Camera.main.transform.position.z));

        //movement
        rb.velocity = transform.right * speed;
    }

    // Update is called once per frame
    void Update()
    {
        //out of bounds (bewerk nummers zodat hij later word gedestroyed)
        if (transform.position.x > screenBounds.x * 10 || transform.position.x < screenBounds.x * -10 || transform.position.y > screenBounds.y * 8)
        {
            DestroyBullet();
        }
    }

    public void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log(other.name);
        
        EnemyHealth enemy = other.GetComponent<EnemyHealth>();
        if(enemy != null)
        {
            enemy.TakeDamage(damage);
        }
        
        DestroyBullet();
    }

    private void DestroyBullet()
    {
        Destroy(gameObject);
    }
}
