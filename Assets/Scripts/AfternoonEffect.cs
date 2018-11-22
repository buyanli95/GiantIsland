using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AfternoonEffect : MonoBehaviour {
    private Light lt;
	// Use this for initialization
	void Start () {
        lt = GetComponent<Light>();
	}
	
	// Update is called once per frame
	void Update () {
        //afternoon effect
        if (lt.intensity < 4)
        {
            lt.intensity += Time.deltaTime * 5;
        }
    }
}
