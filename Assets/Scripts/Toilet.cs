using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Toilet : MonoBehaviour
{
    public GameObject Flush;

    public AudioSource toiletFlush;

    // Start is called before the first frame update

    void OnTriggerEnter(Collider other)
    {
        toiletFlush.Play();
    }
}