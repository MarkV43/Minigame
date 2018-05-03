using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightFlickerer : MonoBehaviour {

    public Gradient colors;
    [Range(-.5f, .5f)]
    public float intensityFlickerMin;
    [Range(-.5f, .5f)]
    public float intensityFlickerMax;

    [Range(0.1f, 50f)]
    public float colorSpeed = 1f;
    [Range(0.1f, 50f)]
    public float intensitySpeed = 1f;

    Light light;
    float defIntensity;

    float offsetCol;
    float offsetInt;

	// Use this for initialization
	void Start () {
        light = GetComponent<Light>();
        defIntensity = light.intensity;

        offsetCol = Random.Range(0f, 99999f);
        offsetInt = Random.Range(0f, 99999f);
    }
	
	// Update is called once per frame
	void Update () {

        light.color = colors.Evaluate(Mathf.PerlinNoise(Time.time * colorSpeed, offsetCol));
        light.intensity = defIntensity + Map(Mathf.PerlinNoise(Time.time * intensitySpeed, offsetInt), 0, 1, intensityFlickerMin, intensityFlickerMax);

        //light.intensity = defIntensity + Random.Range(intensityFlickerMin, intensityFlickerMax);
        //light.color = colors.Evaluate(Random.Range(0f, 1f));
	}

    float Map(float n, float b1, float e1, float b2, float e2) {
        return (n - b1) / (e1 - b1) * (e2 - b2) + n;
    }
}
