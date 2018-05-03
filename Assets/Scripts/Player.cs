using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

    public Transform camera;
    public float yOffset = 3;

	// Use this for initialization
	void Start () {
        //body = GetComponent<Rigidbody>();
        //prevVelocity = Vector3.zero;
	}
	
	// Update is called once per frame
	void Update () {
        /*if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow)) {
            this.transform.localPosition += new Vector3(-runVelocity, 0, 0);
        } else if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow)) {
            this.transform.localPosition += new Vector3(runVelocity, 0, 0);
        }*/
        Vector3 newPos = new Vector3(transform.position.x, transform.position.y + yOffset, camera.position.z);
        camera.position = Vector3.Lerp(camera.position, newPos, Time.deltaTime);

    }
}
