using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class carMove : MonoBehaviour
{
    public GameObject car;

    public float movementSpeed = 15;

    private bool carIsHere;
    // Start is called before the first frame update
    void Start()
    {
        carIsHere = false;
    }

    // Update is called once per frame
    void Update()
    {

        // Moves the object backwards at 15 units per second.
        car.transform.Translate(Vector3.back * movementSpeed * Time.deltaTime);

        if(carIsHere == true) // Teleports the car if it collidies with "Car tag"
        {
            transform.position = new Vector3(3.5f, 0, 50);
            car.transform.Translate(Vector3.back * movementSpeed * Time.deltaTime);
        }

    }
    private void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.tag == "Car")
        {
            carIsHere = true;
            Debug.Log("car here");
        }
    }
    private void OnTriggerExit(Collider col)
    {
        if (col.gameObject.tag == "Car")
        {
            carIsHere = false;
        }
    }
}
