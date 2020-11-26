using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dash : MonoBehaviour
{
    public float dashSpeed;
    private float dashTime;
    public float startDashTime;
    private int direction;
    private Rigidbody2D rigidbody;
    private float moveInput;
   void Start()
   {
     rigidbody = GetComponent<Rigidbody2D>();

     dashTime = startDashTime;
   }

   void Update()
   {                                        //de dash word bepaalt of het op 1 of op 2 staat links,rechts
        if(direction == 0)
        {
            if(Input.GetKeyDown(KeyCode.LeftShift))
            {
                if(moveInput < 0)
                {
                    direction = 1;
                }else if (moveInput > 0)
                {
                    direction = 2;
                }
            }
        }else
        {
            if(dashTime <= 0)
            {
                direction = 0;
                dashTime = startDashTime;
                rigidbody.velocity = Vector2.zero;
            }else
            {
                dashTime -= Time.deltaTime;

                if(direction == 1)
                {
                    rigidbody.velocity = Vector2.left * dashSpeed;
                }else if (direction == 2)
                {
                    rigidbody.velocity = Vector2.right * dashSpeed;
                }
            }
        }
        
    }
}
