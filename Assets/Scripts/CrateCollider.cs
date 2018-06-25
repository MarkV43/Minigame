using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrateCollider : MonoBehaviour {
    //[HideInInspector]
    public GameObject colliding = null;

    public List<string> tagFilter = new List<string>();

    // This class's responsible for detecting a collision
    // and storing the colliding object, as long as it's
    // tag belongs to a list

    // When object enters, store it
    void OnTriggerEnter(Collider c) {
        print(c.tag);
        if(Contains(tagFilter, c.tag)) {
            colliding = c.gameObject;
        }
    }

    // When object exits, store null
    void OnTriggerExit(Collider c) {
        if(colliding == c.gameObject) {
            colliding = null;
        }
    }

    // Check if object has the tag
    bool Contains(List<string> l, string s) {
        foreach (string str in l) {
            if (str == s) {
                return true;
            }
        }
        return false;
    } 
}
