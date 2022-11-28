using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class LightSwitch : MonoBehaviour
{

    public GameObject lightOn, lightOff;
    public bool toggle;
    public AudioSource switchSound;

    void OnTriggerEnter(Collider other)
    {
        if (toggle == true)
        {
            lightOn.SetActive(true);
            lightOff.SetActive(false);
            toggle = false;
            switchSound.Play();
        }
        if (toggle == false)
        {
            lightOn.SetActive(false);
            lightOff.SetActive(true);
            toggle = true;
            switchSound.Play();
        }
    }
}
