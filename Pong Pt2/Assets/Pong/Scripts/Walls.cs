using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Walls : MonoBehaviour
{
    public AudioClip wallSound;
    private void OnCollisionEnter(Collision collision)
    {
        AudioSource audioSource = GetComponent<AudioSource>();
        audioSource.clip = wallSound;
        audioSource.Play();
    }
}
