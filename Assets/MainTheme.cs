using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainTheme : MonoBehaviour
{
    void Start()
    {
        FindObjectOfType<AudioManager>().play("THEME");
    }
}
