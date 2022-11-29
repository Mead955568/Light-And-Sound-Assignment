using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Sink : MonoBehaviour
{
    public GameObject particals;
    public bool toggle;
    public AudioSource sinkSound;

    // Start is called before the first frame update

    void OnTriggerEnter(Collider other)
    {
        if (toggle == false)
        {
            particals.SetActive(true);
            toggle = true;
            sinkSound.Play();
        }
        else
        {
            particals.SetActive(false);
            toggle = false;
            sinkSound.Stop();
        }
    }
}