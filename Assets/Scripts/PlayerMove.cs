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
    public float MinimumX = -90F;
    public float MaximumX = 90F;

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

        cameraRot = ClampRotationAroundXAxis(cameraRot);

        Camera.transform.localRotation = cameraRot;
        Player.transform.localRotation = playerRot;
    }

    private void FixedUpdate()
    {
        transform.position += transform.forward * movementSpeed;
    }

    Quaternion ClampRotationAroundXAxis(Quaternion q)
    {
        q.x /= q.w;
        q.y /= q.w;
        q.z /= q.w;
        q.w = 1.0f;

        float angleX = 2.0f * Mathf.Rad2Deg * Mathf.Atan(q.x);

        angleX = Mathf.Clamp(angleX, MinimumX, MaximumX);

        q.x = Mathf.Tan(0.5f * Mathf.Deg2Rad * angleX);

        return q;
    }
}
