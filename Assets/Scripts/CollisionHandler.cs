using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionHandler : MonoBehaviour {

    public GameObject Objects;

    private GameObject collidedObject;

    void Start() {

    }

    void Update() {

	}

    void OnTriggerEnter(Collider other) {
        Debug.Log("trigger entered");
        collidedObject = other.gameObject;
        Transform collidedParent = collidedObject.transform.parent;
        if (collidedParent.gameObject == Objects)
        {
            ObjectsController objectsController = (ObjectsController) Objects.GetComponent(typeof(ObjectsController));
            objectsController.handleCollision(collidedObject);
        }
    }
}
