﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Warp : MonoBehaviour {

    public Transform warpTarget;

    IEnumerator OnTriggerEnter2D(Collider2D other) {

        Debug.Log("Object Collided");

        ScreenFader sf = GameObject.FindGameObjectWithTag("Fader").GetComponent<ScreenFader>();

        Debug.Log("Pre Fade Out");

        yield return StartCoroutine (sf.FadeToBlack());

        Debug.Log("WOAH!!!!!!");

        other.gameObject.transform.position = warpTarget.position;
        Camera.main.transform.position = warpTarget.position;

        yield return StartCoroutine (sf.FadeToClear());

        Debug.Log("Fade In Complete");

    }
}
