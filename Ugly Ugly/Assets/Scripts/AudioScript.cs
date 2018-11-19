using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioScript : MonoBehaviour
{

    public AudioClip clip;
    public AudioSource source;

    // Use this for initialization
    void Start()
    {




    }
        // Update is called once per frame
        void Update()
{
       

    }
   
    public void PlaySound()
    {
        source.PlayOneShot(clip);
    }

}