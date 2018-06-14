using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrateCollider : MonoBehaviour {
    //[HideInInspector]
    public GameObject colliding = null;

    public List<string> tagFilter = new List<string>();

    void OnTriggerEnter(Collider c) {
        print(c.tag);
        if(Contains(tagFilter, c.tag)) {
            colliding = c.gameObject;
        }
    }

    void OnTriggerExit(Collider c) {
        if(colliding == c.gameObject) {
            colliding = null;
        }
    }
	
    bool Contains(List<string> l, string s) {
        foreach (string str in l) {
            if (str == s) {
                return true;
            }
        }
        return false;
    } 
}
