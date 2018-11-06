﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteract : MonoBehaviour
{

    public GameObject currentInterObj = null;
    public InteractionObject currentInterObjScript = null;
    public Inventory inventory;

    void Update()
    {
        if (Input.GetButtonDown("Interact") && currentInterObj)
        {
            //Check if object is meant to be picked up and stored in inventory
            if(currentInterObjScript.inventory) {
                inventory.AddItem(currentInterObj);

            }

            //Check if object can be opened
            if(currentInterObjScript.openable) {

                //Check if object is locked
                if(currentInterObjScript.locked) {

                    //Check if we have object needed to unlock
                    //Search inventory for object - if found, unlock object
                    if(inventory.FindItem (currentInterObjScript.itemNeeded)) {
                        //item found
                        currentInterObjScript.locked = false;
                        Debug.Log(currentInterObj.name + " was unlocked");
                    } else {
                        Debug.Log(currentInterObj.name + " was not unlocked");
                    }
                } else {
                    //object is not locked - open the object
                    Debug.Log(currentInterObj.name + " is unlocked");
                }
            }


        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("InterObject"))
        {
            Debug.Log(other.name);
            currentInterObj = other.gameObject;
            currentInterObjScript = currentInterObj.GetComponent<InteractionObject>();
        }

    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("InterObject"))
        {
            if (other.gameObject == currentInterObj)
            {
                currentInterObj = null;
            }

        }
    }
}