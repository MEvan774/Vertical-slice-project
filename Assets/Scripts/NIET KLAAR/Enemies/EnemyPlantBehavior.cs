using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPlantBehavior : MonoBehaviour
{
    public float idleTimer;
    public float JumpSpeed;
    public float JumpHeight;

    private bool isDown = true;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (isDown && Time.time >= idleTimer)
        {
            //Jump
        }
    }
}
