using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rope : MonoBehaviour {

	public bool temPai;
	public Transform connectTo;

	// Use this for initialization
	void Start () {
		gameObject.AddComponent<CharacterJoint>();
		//if (!temPai) {
		GetComponent<CharacterJoint>().connectedBody = transform.parent.GetComponent<Rigidbody>();
        //transform.parent = null; 
		//}
	}
	
	// Update is called once per frame
	void Update () {
		/*
		*if(temPai && connectTo != null){ 
		*	transform.position = connectTo.position;
		*	print(connectTo);
		*}
		*/
	}
}
