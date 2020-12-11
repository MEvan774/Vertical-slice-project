using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Alpha : MonoBehaviour
{
    public GameObject currentObject;
    public float alpha;


    // Start is called before the first frame update
    void Start()
    {
        currentObject = gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        ChangeAlpha(currentObject.GetComponent<Renderer>().material, alpha);
    }

    void ChangeAlpha(Material mat, float alphaVal)
    {
        Color oldColor = mat.color;
        Color newColor = new Color(oldColor.r, oldColor.g, oldColor.b, alphaVal);
        mat.SetColor("_Color", newColor);
    }
}
