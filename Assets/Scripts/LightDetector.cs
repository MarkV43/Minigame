using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightDetector : MonoBehaviour {

    public List<Transform> lights;
    //[HideInInspector]
    public bool inDark;
	
	// Update is called once per frame
	void Update () {
        // Reset
        inDark = true;
        // For each light given
        foreach (Transform light in lights) {
            // Get the direction (difference)
            Vector3 dir = transform.position - light.position;
            RaycastHit hit;
            // Raycast from the light to the player, in the range of the light
            if (Physics.Raycast(light.position, dir, out hit, light.gameObject.GetComponent<Light>().range)) {
                // If collided object is a Player
                if (hit.collider.gameObject.tag == "Player") {
                    // He is colliding with the light
                    inDark = false;
                }
            }
        }
        
	}
}
