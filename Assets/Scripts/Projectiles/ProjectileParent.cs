using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileParent : MonoBehaviour
{
    public float speed;
    public Rigidbody2D rb;

    [SerializeField]
    //protected Vector2 screenBounds;
    //public Transform viewPos;

    public int damage;

    public int time;

    protected virtual void Start()
    {
        //Beweging
        rb.velocity = transform.right * speed;
    }

    protected virtual void LateUpdate()
    {
        time--;

        if(time <= 0)
        {
            DestroyBullet();
        }
        //screenBounds = new Vector2(viewPos.position.x, viewPos.position.y);

        //screenBounds = Camera.main.ScreenToViewportPoint(new Vector3(Screen.width, Screen.height, Camera.main.transform.position.z));

        //Vector3 viewPos = transform.position;
        //viewPos.x = Mathf.Clamp(viewPos.x, screenBounds.x, screenBounds.x * -1);
        //viewPos.y = Mathf.Clamp(viewPos.y, screenBounds.y, screenBounds.y * -1);
        //rb.position = viewPos;

        //out of bounds (bewerk nummers zodat hij later word gedestroyed)
        //if (transform.position.x > screenBounds.x * 10 || transform.position.x < screenBounds.x * -10 || transform.position.y > screenBounds.y * 8)
    }

    protected void DestroyBullet()
    {
        Destroy(gameObject);
    }


        //Debug.LogWarning("BulletOUtScreen");
       // DestroyBullet();

}
