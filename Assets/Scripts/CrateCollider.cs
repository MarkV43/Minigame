using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrateCollider : MonoBehaviour {
    //[HideInInspector]
    public GameObject colliding = null;

    public string tagFilter = "Crate";

    void OnTriggerEnter(Collider c) {
        print(c.tag);
        if(c.tag == tagFilter) {
            colliding = c.gameObject;
        }
    }

    void OnTriggerExit(Collider c) {
        if(colliding == c.gameObject) {
            colliding = null;
        }
    }
	
}
