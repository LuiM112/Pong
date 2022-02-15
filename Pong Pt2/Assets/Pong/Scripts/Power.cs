using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Power : MonoBehaviour
{
    public GameObject left;
    public GameObject right;
    public GameObject ball;
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("speed triggered");
        if (left.GetComponent<Renderer>().material.color == ball.GetComponent<Renderer>().material.color)
        {
            ball.GetComponent<Rigidbody>().velocity *= 2f;
            
        }
        if (right.GetComponent<Renderer>().material.color == ball.GetComponent<Renderer>().material.color)
        {
            ball.GetComponent<Rigidbody>().velocity *= 2f;
        }
        
    }
}
