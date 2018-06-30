using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElevatorCollider : MonoBehaviour {

    public CrateCollider crateCollider;
    public Transform lamp;
    Rigidbody rigidbody;
    float origY;
    float lx, ly, lz;

	// Use this for initialization
	void Start () {
        rigidbody = GetComponent<Rigidbody>();
        // Store elevator's origin
        origY = transform.position.y;
        // Store lamp's origin
        ly = lamp.position.y;
        lx = lamp.position.x;
        lz = lamp.position.z;
	}
	
	// Update is called once per frame
	void Update () {
        // Seting velocity accordingly to collisions and position
		if(crateCollider.colliding) {
            rigidbody.velocity = -transform.up;
        } else if(transform.position.y < origY) {
            rigidbody.velocity = transform.up;
        } else {
            rigidbody.velocity = Vector3.zero;
        }

        // Place the lamp proportionally to the origin of the elevator
        lamp.position = new Vector3(lx, ly + origY - rigidbody.position.y, lz);
    }
}
