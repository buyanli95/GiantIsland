using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioBird : MonoBehaviour {
    private AudioSource s;
    public float volumnMax;
	// Use this for initialization
	void Start () {
        s=GetComponent<AudioSource>();
	}
	
	// Update is called once per frame
	void Update () {
		if(s.volume < volumnMax)
        {
            s.volume += 0.1f * Time.deltaTime;
        }
	}
}
