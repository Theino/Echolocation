using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectsController : MonoBehaviour {

    public GameObject GoalObject;
    public float WorldSize = 20f;
    public int maxFish = 3;

    private GameObject player;
    private AudioSource capturedSource;
    private float lastTime;
    private int currFish = 0;

    // Use this for initialization
    void Start () {
        player = GameObject.Find("Player");
        capturedSource = transform.GetComponent<AudioSource>();

        createNewFish();
        lastTime = Time.time;
    }
	
	// Update is called once per frame
	void Update ()
    {
        if (currFish < maxFish)
        {
            if (lastTime < Time.time - 0.5)
            {
                createNewFish();
                lastTime = Time.time;
            }
        }
	}

    public void handleCollision(GameObject collidedObject)
    {
        capturedSource.Play();
        Debug.Log("Captured");
        float newX = Random.Range(-WorldSize / 2f, WorldSize / 2f);
        float newY = Random.Range(-WorldSize / 2f, WorldSize / 2f);
        float newZ = Random.Range(-WorldSize / 2f, WorldSize / 2f);
        collidedObject.transform.position = new Vector3(newX, newY, newZ);
    }

    public void createNewFish()
    {
        Debug.Log("Fish created");
        GameObject newGoalObject = Instantiate(GoalObject, transform);
        float newX = Random.Range(-WorldSize / 2f, WorldSize / 2f);
        float newY = Random.Range(-WorldSize / 2f, WorldSize / 2f);
        float newZ = Random.Range(-WorldSize / 2f, WorldSize / 2f);
        newGoalObject.transform.position = new Vector3(newX, newY, newZ);
        currFish++;
    }
}
