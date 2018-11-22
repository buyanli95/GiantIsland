using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class flowerRotation2 : MonoBehaviour {
    public int scaleMax;
    // Use this for initialization
    void Start () {
        
	}
	
	// Update is called once per frame
	void Update () {
        if (transform.localScale.x < scaleMax)
        {
            transform.localScale += new Vector3(20f, 20f, 20f) * Time.deltaTime;
            //transform.Rotate(0, Random.Range(0f, 5f), 0);
        }

        if (transform.localScale.x < scaleMax)
        {
            transform.Rotate(0, 20 * Time.deltaTime, 0, 0);
        }
        else
        {
            transform.Rotate(0, 5 * Time.deltaTime, 0, 0);
        }
    }
}
