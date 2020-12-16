using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class YouDied : MonoBehaviour
{
    public GameObject GameOverPanel;

    public void AnimEndEvent()
    {
        GameOverPanel.SetActive(true);
        this.gameObject.SetActive(false);
    }
}
