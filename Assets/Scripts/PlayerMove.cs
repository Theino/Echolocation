using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class PlayerMove : MonoBehaviour {

    public float XSensitivity = 2f;
    public float YSensitivity = 2f;
    public GameObject Camera;
    public GameObject Player;
    public float movementSpeed = 1f;

    private float timeLastPressed;
    private float timeDelayBetweenClicks = 1;
    private Quaternion cameraRot;
    private Quaternion playerRot;

	private void Start () {
        timeLastPressed = Time.time;
        cameraRot = Camera.transform.localRotation;
        playerRot = Player.transform.localRotation;
	}
	
	private void Update () {
        float xRot = CrossPlatformInputManager.GetAxis("Mouse Y") * XSensitivity;
        float yRot = CrossPlatformInputManager.GetAxis("Mouse X") * YSensitivity;
        
        cameraRot *= Quaternion.Euler(-xRot, 0f, 0f);
        playerRot *= Quaternion.Euler(0f, yRot, 0f);

        Camera.transform.localRotation = cameraRot;
        Player.transform.localRotation = playerRot;
    }

    private void FixedUpdate()
    {
        transform.position += transform.forward * movementSpeed;
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
        if (timeLastPressed < Time.time - timeDelayBetweenClicks)
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
        if (CheckTime())
            Debug.Log("Forward");
    }

    private void MoveRight()
    {
        if (CheckTime())
            Debug.Log("Right");
    }
    private void MoveLeft()
    {
        if (CheckTime())
            Debug.Log("Left");
    }
}
