using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Extendo : MonoBehaviour
{
    public GameObject left;
    public GameObject right;
    public GameObject ball;

    public Vector3 scale = new Vector3(0, 0, 2.5f);
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("length triggered");
        if (left.GetComponent<Renderer>().material.color == ball.GetComponent<Renderer>().material.color)
        {
            left.GetComponent<Transform>().localScale += scale;
        }
        if (right.GetComponent<Renderer>().material.color == ball.GetComponent<Renderer>().material.color)
        {
            right.GetComponent<Transform>().localScale += scale;
        }
        
    }
}
