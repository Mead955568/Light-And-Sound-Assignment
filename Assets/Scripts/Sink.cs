using System.Collections;
using System.Collections.Generic;
using UnityEditor.Presets;
using UnityEngine;
using UnityEngine.Events;

public class Sink : MonoBehaviour
{
    public GameObject button;
    public GameObject Partical;
    public UnityEvent onPress;
    public UnityEvent onRelease;
    public ParticleSystem water;
    AudioSource sound;
    GameObject presser;
    bool isPressed;

    // Start is called before the first frame update
    void Start()
    {
        sound = GetComponent<AudioSource>();
        isPressed = false;
        water.Stop();
        Partical.SetActive(false);
    }

    // Update is called once per frame

    private void OnTriggerEnter(Collider other)
    {
        if (!isPressed)
        {
            onPress.Invoke();
            sound.Play();
            isPressed = true;
            water.Play();
            Partical.SetActive(true);
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other == presser)
        {
            onRelease.Invoke();
            isPressed = false;
            water.Stop();
            Partical.SetActive(false);
        }
    }
}