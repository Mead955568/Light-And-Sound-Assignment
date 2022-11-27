using GLTFast.Schema;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class busMove : MonoBehaviour
{
    public GameObject bus;

    public float movementSpeed = 10;

    private bool busIsHere;
    // Start is called before the first frame update
    void Start()
    {
        busIsHere = false;
    }

    // Update is called once per frame
    void Update()
    {

        // Moves the object backwards at 10 units per second.
        bus.transform.Translate(Vector3.forward * movementSpeed * Time.deltaTime);

        if (busIsHere == true)
        {
            transform.position = new Vector3(6.5f, 0, -15);
            bus.transform.Translate(Vector3.back * movementSpeed * Time.deltaTime);
        }

    }
    private void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.tag == "Car2")
        {
            busIsHere = true;
            Debug.Log("car2 here");
        }
    }
    private void OnTriggerExit(Collider col)
    {
        if (col.gameObject.tag == "Car2")
        {
            busIsHere = false;
        }
    }
}
