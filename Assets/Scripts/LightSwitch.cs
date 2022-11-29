using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using static UnityEngine.ParticleSystem;

public class LightSwitch : MonoBehaviour
{

    public GameObject lightOn, lightOff;
    public bool toggle;
    public AudioSource switchSound;

    // Start is called before the first frame update

    void OnTriggerEnter(Collider other)
    {
        Debug.Log("LightHit");

        if (toggle == false)
        {
            lightOn.SetActive(true);
            lightOff.SetActive(false);
            toggle = true;
            switchSound.Play();
            Debug.Log("LightOn");
        }
        else
        {
            lightOff.SetActive(true);
            lightOn.SetActive(false);
            toggle = false;
            switchSound.Play();
            Debug.Log("LightOff");
        }
    }
}

