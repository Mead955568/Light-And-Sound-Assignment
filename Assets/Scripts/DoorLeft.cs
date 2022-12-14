using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorLeft : MonoBehaviour
{
    public AnimationCurve openSpeedCurve = new AnimationCurve(new Keyframe[] { new Keyframe(0, 1, 0, 0), new Keyframe(0.8f, 1, 0, 0), new Keyframe(1, 0, 0, 0) }); //Contols the open speed at a specific time
    public enum OpenDirection { x, y, z }
    public OpenDirection direction = OpenDirection.y;
    public float openDistance = 3f; // How far should door move
    public float openDistance2 = 3f;
    public float openSpeedMultiplier = 2.0f; // Value for door speed
    public Transform doorBody; // Left door body Transform
    public Transform doorBody2; // Right door boby Transform
    bool open = false;

    public AudioSource doorOpen;
    public AudioSource doorClose;

    Vector3 defaultDoorPosition;
    Vector3 currentDoorPosition;
    Vector3 defaultDoorPosition2;
    Vector3 currentDoorPosition2;

    float openTime = 0;

    void Start()
    {
        if (doorBody)
        {
            defaultDoorPosition = doorBody.localPosition; // Sets the doors origin position 
            defaultDoorPosition2 = doorBody2.localPosition;
        }

        // Set Collider as trigger
        GetComponent<Collider>().isTrigger = true;
    }

    // Main function
    void Update()
    {
        if (!doorBody) // if statment to move each door
            return;

        if (openTime < 1)
        {
            openTime += Time.deltaTime * openSpeedMultiplier * openSpeedCurve.Evaluate(openTime);
        }

        if (direction == OpenDirection.x)
        {
            doorBody.localPosition = new Vector3(Mathf.Lerp(currentDoorPosition.x, defaultDoorPosition.x + (open ? openDistance : 0), openTime), doorBody.localPosition.y, doorBody.localPosition.z);
            doorBody2.localPosition = new Vector3(Mathf.Lerp(currentDoorPosition2.x, defaultDoorPosition2.x + (open ? openDistance2 : 0), openTime), doorBody2.localPosition.y, doorBody2.localPosition.z);
        }
        else if (direction == OpenDirection.y)
        {
            doorBody.localPosition = new Vector3(doorBody.localPosition.x, Mathf.Lerp(currentDoorPosition.y, defaultDoorPosition.y + (open ? openDistance : 0), openTime), doorBody.localPosition.z);
            doorBody2.localPosition = new Vector3(doorBody2.localPosition.x, Mathf.Lerp(currentDoorPosition2.y, defaultDoorPosition2.y + (open ? openDistance2 : 0), openTime), doorBody2.localPosition.z);
        }
        else if (direction == OpenDirection.z)
        {
            doorBody.localPosition = new Vector3(doorBody.localPosition.x, doorBody.localPosition.y, Mathf.Lerp(currentDoorPosition.z, defaultDoorPosition.z + (open ? openDistance : 0), openTime));
            doorBody2.localPosition = new Vector3(doorBody2.localPosition.x, doorBody2.localPosition.y, Mathf.Lerp(currentDoorPosition2.z, defaultDoorPosition2.z + (open ? openDistance2 : 0), openTime));
        }
    }

    // Activate the Main function when Player enter the trigger area
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            open = true;
            currentDoorPosition = doorBody.localPosition;
            currentDoorPosition2 = doorBody2.localPosition;
            openTime = 0; // Activates the earlier "if" statement
            doorOpen.Play();
        }
    }

    // Deactivate the Main function when Player exit the trigger area
    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            open = false;
            currentDoorPosition = doorBody.localPosition;
            currentDoorPosition2 = doorBody2.localPosition;
            openTime = 0;
            doorClose.Play();
        }
    }
}