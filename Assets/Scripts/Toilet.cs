using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.Experimental.GraphView.GraphView;
using UnityEngine.Events;

public class Toilet : MonoBehaviour
{
    public GameObject button;
    public UnityEvent onPress;
    public UnityEvent onRelease;
    AudioSource sound;
    GameObject presser;
    bool isPressed;

// Start is called before the first frame update
void Start()
{
    sound = GetComponent<AudioSource>();
    isPressed = false;
}

// Update is called once per frame

private void OnTriggerEnter(Collider other)
{
    if (!isPressed)
    {
        onPress.Invoke();
        sound.Play();
        isPressed = true;
    }
}
private void OnTriggerExit(Collider other)
{
    if (other == presser)
    {
        onRelease.Invoke();
        isPressed = false;
    }
}
}