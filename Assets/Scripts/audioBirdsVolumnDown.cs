using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class audioBirdsVolumnDown : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (GetComponent<AudioSource>().volume > 0)
        {
            GetComponent<AudioSource>().volume -= Time.deltaTime * 0.1f;
        }
    }
}
