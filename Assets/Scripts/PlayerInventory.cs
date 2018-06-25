using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInventory : MonoBehaviour {

    public class Key {
        public string name;
    }

    public GameObject holding;
    public Key[] keys;

    CrateCollider holdTrigger;

	// Use this for initialization
	void Start () {
        holdTrigger = transform.GetChild(transform.childCount - 1).GetComponent<CrateCollider>();
	}
	
	// Update is called once per frame
	void Update () {
        // If F is pressed
        if (Input.GetKeyDown(KeyCode.F)) {
            // If player's collision is empty
            if (holdTrigger.colliding == null) {
                // If player is holding something
                if (holding != null) {
                    // Place the object in front of the player
                    holding.transform.position = transform.position + transform.forward + transform.up / 2;
                    holding.GetComponent<Rigidbody>().velocity = Vector3.zero;
                    holding.GetComponent<BoxCollider>().isTrigger = false;
                    // Change object's layer to collide with light
                    holding.layer = LayerMask.NameToLayer("Default");
                    foreach (Transform t in holding.transform) {
                        t.gameObject.layer = LayerMask.NameToLayer("Default");
                    }
                    holding = null;
                }
            // If player is holding nothing
            } else if (holding == null) {
                // Grab the object
                holding = holdTrigger.colliding;
                holding.GetComponent<BoxCollider>().isTrigger = true;
                // Change object's layer to not collide with light
                holding.layer = LayerMask.NameToLayer("IgnoreLight");
                foreach (Transform t in holding.transform) {
                    t.gameObject.layer = LayerMask.NameToLayer("IgnoreLight");
                }
            }
        }

        // If player is holding something
		if(holding != null) {
            // Set object's position to above the player
            Vector3 v3 = transform.position;
            v3.y += 1.5f;
            holding.transform.position = v3;
            holding.transform.rotation = Quaternion.identity;
        }
	}
}
