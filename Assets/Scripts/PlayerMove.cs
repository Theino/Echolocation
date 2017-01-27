using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;
using UnityEngine.SceneManagement;

public class PlayerMove : MonoBehaviour
{

    public float XSensitivity = 2f;
    public float YSensitivity = 2f;
    public GameObject Camera;
    public GameObject Player;
    public float movementSpeed = 1f;
    public float MinimumX = -90F;
    public float MaximumX = 90F;
    public bool lockCursor = true;
    public GameObject MovementParticles;

    private float timeLastPressed;
    private float timeDelayBetweenClicks = 1;
    private Quaternion cameraRot;
    private Quaternion playerRot;

    private bool cursorIsLocked = true;
    private bool dPadPressed = false;

    private float xRot = 0f;

    private void Start()
    {
        timeLastPressed = Time.time;
        cameraRot = Camera.transform.localRotation;
        playerRot = Player.transform.localRotation;
    }

    private void Update()
    {
        xRot += CrossPlatformInputManager.GetAxis("Mouse Y") * XSensitivity;
        float yRot = CrossPlatformInputManager.GetAxis("Mouse X") * YSensitivity;

        xRot = Mathf.Clamp(xRot, -89, 89);

        cameraRot.eulerAngles = new Vector3(-xRot, 0f, 0f);
        playerRot *= Quaternion.Euler(0f, yRot, 0f);


        Player.transform.localRotation = playerRot;
        Camera.transform.localRotation = cameraRot;


        UpdateCursorLock();


        if (OVRInput.Get(OVRInput.Button.One))
            dPadPressed = !dPadPressed;
    }

    private void FixedUpdate()
    {
        if (OVRInput.Get(OVRInput.Button.Two))
        {
            transform.parent.position = new Vector3(0f, 0f, 0f);
            SceneManager.LoadScene("MainMenu");
        }

        if (Input.GetButton("Swim") || dPadPressed)
        {         
            transform.parent.position += transform.forward * movementSpeed;
            MovementParticles.SetActive(true);
        }
        else
        {
            MovementParticles.SetActive(false);
        }
        OVRInput.FixedUpdate();
    }

    public void SetCursorLock(bool value)
    {
        lockCursor = value;
        if (!lockCursor)
        {
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }
    }

    public void UpdateCursorLock()
    {
        if (lockCursor)
            InternalLockUpdate();
    }

    private void InternalLockUpdate()
    {
        if (Input.GetKeyUp(KeyCode.Escape))
        {
            cursorIsLocked = false;
        }
        else if (Input.GetMouseButtonUp(0))
        {
            cursorIsLocked = true;
        }

        if (cursorIsLocked)
        {
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
        }
        else if (!cursorIsLocked)
        {
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }
    }
}
