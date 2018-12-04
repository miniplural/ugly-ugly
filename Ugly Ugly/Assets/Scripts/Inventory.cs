using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    public GameObject[] inventory = new GameObject[10];

    public void AddItem(GameObject item)
    {
        bool itemAdded = false;

        //Find first open slot
        for (int i = 0; i < inventory.Length; i++)
        {
            if (inventory[i] == null)
            {
                inventory[i] = item;
                Debug.Log(item.name + " was added");
                itemAdded = true;
                //Do something with the object
                item.SendMessage("DoInteraction");
                break;
            }
        }

        //Inventory full
        if (!itemAdded)
        {
            Debug.Log("inventory full");
        }

    }

    public bool FindItem(GameObject item)
    {
        for (int i = 0; i < inventory.Length; i++)
        {
            if (inventory[i] == item)
            {
                //found item
                return true;
            }
        }
        //item not found
        return false;
    }

    public GameObject FindItemByType(string itemType)
    {
        for (int i = 0; i < inventory.Length; i++)
        {
            if (inventory[i] != null)
            {
                if (inventory[i].GetComponent<InteractionObject>().itemType == itemType)
                {
                    //we found item of type we were looking for
                    return inventory[i];
                }
            }
        }
        //item of type not found
        return null;
    }

    public void RemoveItem(GameObject item)
    {
        for (int i = 0; i < inventory.Length; i++)
        {
            if (inventory[i] != null)
            {
                if (inventory[i] == item)
                {
                    //we found item - remove it
                    inventory[i] = null;
                    Debug.Log(item.name + " was removed");
                    break;
                }
            }
        }
    }
}
