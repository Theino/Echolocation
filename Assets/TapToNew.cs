using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TapToNew : MonoBehaviour {

    public Scene playScene;

    private bool dPadPressed = false;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (OVRInput.Get(OVRInput.Button.One))
            dPadPressed = !dPadPressed;
    }

    void FixedUpdate()
    {
        if (dPadPressed)
        {
            SceneManager.LoadScene("Main");
        }
        OVRInput.FixedUpdate();
    }
}
