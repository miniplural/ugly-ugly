using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractionObject : MonoBehaviour
{
    public bool inventory;  //if true, object can be stored in inventory
    public bool openable;   //if true, object can be opened (door)
    public bool locked;     //if true, object is locked (requires another object)
    public bool talks;      //if true, object can talk to player
    public GameObject itemNeeded; //item needed in order to interact with this item

    public Animator anim;

    public string message;  //the message this object will give the player

    public void DoInteraction()
    {
        //Picked up and put in inventory
        gameObject.SetActive (false);
    }

    public void Open()
    {
        anim.SetBool("open", true);
    }

    public void Talk()
    {
        Debug.Log(message);
    }

}
