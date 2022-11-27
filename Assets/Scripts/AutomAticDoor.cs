using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutomAticDoor : MonoBehaviour
{

    public GameObject movingDoorL;
    public GameObject movingDoorR;
    public GameObject soundO;
    public GameObject soundC;

    public float maximumOpeningL = 10f;
    public float maximumClosingL = 0f;
    public float maximumOpeningR = 10f;
    public float maximumClosingR = 0f;

    public float movementSpeed = 5f;

    bool playerIsHere;

    // Start is called before the first frame update
    void Start()
    {
        playerIsHere = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (playerIsHere == true)
        {
            if (movingDoorL.transform.position.x < maximumOpeningL)
            {
                movingDoorL.transform.Translate(-movementSpeed * Time.deltaTime, 0f, 0f);
                movingDoorR.transform.Translate(movementSpeed * Time.deltaTime, 0f, 0f);
            }
        }
        else
        {
            if (movingDoorL.transform.position.x > maximumClosingL)
            {
                movingDoorL.transform.Translate(movementSpeed * Time.deltaTime, 0f, 0f);
                movingDoorR.transform.Translate(-movementSpeed * Time.deltaTime, 0f, 0f);
            }
        }


    }

    private void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.tag == "Player")
        {
            playerIsHere = true;
            Debug.Log("playerhere");
        }
    }

    private void OnTriggerExit(Collider col)
    {
        if (col.gameObject.tag == "Player")
        {
            playerIsHere = false;
        }
    }
}