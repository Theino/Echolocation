using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectsController : MonoBehaviour {

    public GameObject GoalObject;
    public float WorldSize = 20f;

    private GameObject player;
    private AudioSource capturedSource;

    // Use this for initialization
    void Start () {
        player = GameObject.Find("Player");
        capturedSource = transform.GetComponent<AudioSource>();

        GameObject newGoalObject = Instantiate(GoalObject, transform);
        float newX = Random.Range(-WorldSize / 2f, WorldSize / 2f);
        float newY = Random.Range(-WorldSize / 2f, WorldSize / 2f);
        float newZ = Random.Range(-WorldSize / 2f, WorldSize / 2f);
        newGoalObject.transform.position = new Vector3(newX, newY, newZ);
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    public void handleCollision(GameObject collidedObject)
    {
        capturedSource.Play();
        Debug.Log("Captured");
        GameObject newGoalObject = Instantiate(GoalObject,transform);
        float newX = Random.Range(-WorldSize / 2f, WorldSize / 2f);
        float newY = Random.Range(-WorldSize / 2f, WorldSize / 2f);
        float newZ = Random.Range(-WorldSize / 2f, WorldSize / 2f);
        newGoalObject.transform.position = new Vector3(newX, newY, newZ);
        Destroy(collidedObject);
    }
}
