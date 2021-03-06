﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {

    Rigidbody2D rbody;
    Animator anim;

	void Start () {

        rbody = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
		
	}

    void Update()
    {
        //IDLE VS WALK+RUN
        Vector2 movement_vector = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));

        if (movement_vector != Vector2.zero) {
            anim.SetBool("iswalking", true);
            anim.SetFloat("input_x", movement_vector.x);
            anim.SetFloat("input_y", movement_vector.y);
        }

        else {
            anim.SetBool("iswalking", false);
        }


        //RUN VS WALK
        if (Input.GetKey(KeyCode.LeftShift))
            rbody.MovePosition(rbody.position + movement_vector * 6/5 * Time.deltaTime);

        else
        {
            rbody.MovePosition(rbody.position + movement_vector * 4/5 * Time.deltaTime);
        }


    }

}
