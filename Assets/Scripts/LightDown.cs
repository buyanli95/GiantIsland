using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightDown : MonoBehaviour {
    public Light lt;
    public float value;

	// Update is called once per frame
	void Update () {
        if (lt.intensity > value)
        {
            lt.intensity -= Time.deltaTime;
        }
    }
}
