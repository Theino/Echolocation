using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectsController : MonoBehaviour {

    public GameObject[] GoalObjects;
    public float WorldSize = 20f;
    public int maxFish = 3;

    private AudioSource capturedSource;

    private GameObject player;
   
    private float lastTime;
    private float startTime;
    private Queue<GameObject> objectsToPlay;
    private Queue<GameObject> waitingObjectsToPlay;

    // Use this for initialization
    void Start () {
        player = GameObject.Find("Player");
        capturedSource = transform.GetComponent<AudioSource>();
        objectsToPlay = new Queue<GameObject>();
        waitingObjectsToPlay = new Queue<GameObject>();
        for(int i = 0; i < maxFish; i++)
            createNewFish();
        lastTime = Time.time;
        startTime = 0;
    }
	
	// Update is called once per frame
	void FixedUpdate ()
    {
        if (startTime < Time.time - 4)
        {
            Debug.Log("starting");
            objectsToPlay = new Queue<GameObject>(waitingObjectsToPlay);
            waitingObjectsToPlay = new Queue<GameObject>();
            startTime = Time.time;
        }
        if (lastTime < Time.time - 1)
        {
            Debug.Log("lastTime");
            Debug.Log(objectsToPlay.Count.ToString());
            if (objectsToPlay.Count > 0)
            {
                GameObject playingObject = objectsToPlay.Dequeue();
                while (objectsToPlay.Count > 0 && playingObject == null)
                    playingObject = objectsToPlay.Dequeue();
                if (playingObject != null)
                {
                    Debug.Log("play sound");
                    playingObject.GetComponent<AudioSource>().Play();
                    waitingObjectsToPlay.Enqueue(playingObject);
                }
                startTime = Time.time;
            }
            lastTime = Time.time;
        }
    }

    public void handleCollision(GameObject collidedObject)
    {
        capturedSource.Play();
        Debug.Log("Captured");
        createNewFish();
        Destroy(collidedObject);
    }

    public GameObject createNewFish()
    {
        int fishChoiceIndex = Random.Range(0, GoalObjects.Length);
        GameObject newGoalObject = Instantiate(GoalObjects[fishChoiceIndex], transform);
        float newX = Random.Range(-WorldSize / 2f, WorldSize / 2f);
        float newY = Random.Range(-WorldSize / 2f, WorldSize / 2f);
        float newZ = Random.Range(-WorldSize / 2f, WorldSize / 2f);
        newGoalObject.transform.position = new Vector3(newX, newY, newZ);
        newGoalObject.transform.Rotate(new Vector3(0f, 1f, 0f), Random.Range(0, 360));
        if (objectsToPlay.Count > 0)
            objectsToPlay.Enqueue(newGoalObject);
        else
            waitingObjectsToPlay.Enqueue(newGoalObject);
        return newGoalObject;
    }
}
