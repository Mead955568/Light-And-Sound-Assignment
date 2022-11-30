using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class MakeNoise : MonoBehaviour
{
    public AudioSource pickJames;
    // Start is called before the first frame update
    void Start()
    {

    }
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Food"))
        {
            pickJames.Play();
        }
    }
}
