﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuitScript : MonoBehaviour {

    public void quit()
    {
        Application.Quit();
        Debug.Log("Game quit successfully.");
    }
}