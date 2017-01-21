﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour {

    private float timeLastPressed;
    private float timeDelayBetweenClicks = 2;

	// Use this for initialization
	void Start () {
        timeLastPressed = Time.time;
	}
	
	// Update is called once per frame
	void Update () {
        CheckForMove();
        
	}

    private void CheckForMove()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");
        if (horizontalInput > 0)
        {
            MoveRight();
        }
        if (horizontalInput < 0)
        {
            MoveLeft();
        }
        if (verticalInput > 0)
        {
            MoveForward();
        }
        if (verticalInput < 0)
        {
            MoveBackward();
        }
    }

    private void MoveBackward()
    {
        if(CheckTime())
            Debug.Log("Back");
    }

    private bool CheckTime()
    {
        if (timeLastPressed > timeDelayBetweenClicks + Time.time)
        {
            timeLastPressed = Time.time;
            return true;
        }
        else
        {
            return false;
        }
    }
    private void MoveForward()
    {
        Debug.Log("Forward");
    }

    private void MoveRight()
    {
        Debug.Log("Right");
    }
    private void MoveLeft()
    {
        Debug.Log("Left");
    }
}
