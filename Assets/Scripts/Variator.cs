using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Variator : MonoBehaviour {

    public Function function;
    public Vector3 axis;
    public float frequency;
    public float lenght;
    Vector3 origPos;

    void Start() {
        origPos = transform.localPosition;
    }
	
	// Update is called once per frame
	void Update () {
        float freqTime = Time.time % frequency;
        float ang = 2 * freqTime * Mathf.PI / frequency;

        float func = 0;

		switch(function) {
            case Function.Sin:
                func = Mathf.Sin(ang);
                break;
            case Function.Cos:
                func = Mathf.Cos(ang);
                break;
        }

        float x;
        if (axis.x == 0)
            x = transform.localPosition.x;
        else
            x = origPos.x + axis.x * func;
        float y;
        if (axis.y == 0)
            y = transform.localPosition.y;
        else
            y = origPos.y + axis.y * func;
        float z;
        if (axis.z == 0)
            z = transform.localPosition.z;
        else
            z = origPos.z + axis.z * func;
        transform.localPosition = new Vector3(x, y, z);

    }
}

public enum Function {
    Sin, Cos
}