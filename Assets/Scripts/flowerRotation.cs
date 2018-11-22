using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class flowerRotation : MonoBehaviour {
    public int scaleMax;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
       if(transform.localScale.x < scaleMax)
        {
            transform.localScale += new Vector3(20f, 20f, 20f) * Time.deltaTime;
        }

        if (transform.localScale.x < scaleMax)
        {
            transform.Rotate(0, 20 * Time.deltaTime, 0, 0);
        }
    }
}
