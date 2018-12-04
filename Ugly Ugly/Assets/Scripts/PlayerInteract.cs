using System.Collections;
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
            //Check if it can be stored in inventory
            if (currentInterObjScript.inventory)
            {
                inventory.AddItem(currentInterObj);
            }

            //Check to see if object can be opened
            if (currentInterObjScript.openable)
            {

                //check if it's locked
                if (currentInterObjScript.locked)
                {

                    //check if we have object needed to unlock
                    //search inventory for item needed - if found, unlock object
                    if (inventory.FindItem(currentInterObjScript.itemNeeded))
                    {
                        //found item needed, unlock thing
                        currentInterObjScript.locked = false;
                        Debug.Log(currentInterObj.name + " was unlocked");
                    }
                    else
                    {
                        Debug.Log(currentInterObj.name + " was not unlocked");
                    }
                }
                else
                {
                    //object is not locked - open the object
                    Debug.Log(currentInterObj.name + " is unlocked");
                    currentInterObjScript.Open();
                }
            }

            //Check if object talks and has a message
            if (currentInterObjScript.talks)
            {
                //tell the object to give its message
                currentInterObjScript.Talk();
            }
        }
        //Eat an item
        if(Input.GetButtonDown("Space")){
            //check inventory for an edible item
            GameObject edible = inventory.FindItemByType("Edible");
            if(edible != null){
                Debug.Log("nom nom nom nom nom nom nom nom");
                inventory.RemoveItem(edible);
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
        if (other.CompareTag("InterObject")){
            if (other.gameObject == currentInterObj){
                currentInterObj = null;
            }

        }
    }
}
