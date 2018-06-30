using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectDispawner : MonoBehaviour {

    public HUDController hud;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (transform.position.y < -20) {
            string msg;
            switch (tag) {
                case "Player":
                    msg = "You fell and died\nBetter luck next time";
                    break;
                case "Crate":
                    msg = "You dropped a crate and it broke\nBetter luck next time";
                    break;
                default:
                    msg = "You did something wrong\nBetter luck next time";
                    break;
            }
            hud.EndGame(msg);
        }
	}
}
