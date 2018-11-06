using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractionObject : MonoBehaviour
{

    public bool inventory; //if true, object can be stored in inventory
    public bool openable; //if true, object can be opened
    public bool locked; //if true, object is locked
    public GameObject itemNeeded; //item needed in order to interact (ex: key to open locked door)

    public void DoInteraction()
    {

        //Picked up and put in inventory
        gameObject.SetActive (false);
    }

}
