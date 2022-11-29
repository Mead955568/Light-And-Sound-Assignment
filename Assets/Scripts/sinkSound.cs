using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sinkSound : MonoBehaviour
{
    // Start is called before the first frame update
    public AudioSource soundsink;


    // Start is called before the first frame update
    void Start()
    {
        soundsink = GetComponent<AudioSource>();
    }
    void OnTriggerEnter(Collider other)
    {
        soundsink.Play();
    }
}