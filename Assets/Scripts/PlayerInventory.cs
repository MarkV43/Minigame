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

    GameObject inCollision;


    void OnGrab() {

    }

    void OnRelease() {

    }
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.F)) {
            print("1");
            if (holding != null) {
                print("2");
                if (holdTrigger.colliding == null) {
                    print("3");
                    holding.transform.position = transform.position + transform.forward + transform.up / 2;
                    holding.GetComponent<Rigidbody>().velocity = Vector3.zero;
                    holding.GetComponent<BoxCollider>().isTrigger = false;
                    holding.layer = LayerMask.NameToLayer("Default");
                    foreach (Transform t in holding.transform) {
                        t.gameObject.layer = LayerMask.NameToLayer("Default");
                    }
                    holding = null;
                }
            } else if (holdTrigger.colliding != null) {
                print("2");
                holding = holdTrigger.colliding;
                holding.GetComponent<BoxCollider>().isTrigger = true;
                holding.layer = LayerMask.NameToLayer("IgnoreLight");
                foreach (Transform t in holding.transform) {
                    t.gameObject.layer = LayerMask.NameToLayer("IgnoreLight");
                }
            }
        }

		if(holding != null) {
            Vector3 v3 = transform.position;
            v3.y += 1.5f;
            holding.transform.position = v3;
            holding.transform.rotation = Quaternion.identity;
        }
	}
}
