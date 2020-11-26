using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileParent : MonoBehaviour
{
    public float speed;
    public Rigidbody2D rb;
    protected Vector2 screenBounds;

    public int damage;    

    protected virtual void Start()
    {
        //Beweging
        rb.velocity = transform.right * speed;
    }

    void Update()
    {
        //sets screenBounds
        screenBounds = Camera.main.ScreenToViewportPoint(new Vector3(Screen.width, Screen.height, Camera.main.transform.position.z));

        //out of bounds (bewerk nummers zodat hij later word gedestroyed)
        if (transform.position.x > screenBounds.x * 10 || transform.position.x < screenBounds.x * -10 || transform.position.y > screenBounds.y * 8)
        {
            DestroyBullet();
        }
    }

    protected void DestroyBullet()
    {
        Destroy(gameObject);
    }
}
