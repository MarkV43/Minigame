using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Elevador : MonoBehaviour {
	public GameObject player;
	public CrateCollider collider;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (collider.colliding != null) {
			Vector3 v = transform.position;
			v.y -= 0.01f;
			transform.position = v;
		}
	}
}
