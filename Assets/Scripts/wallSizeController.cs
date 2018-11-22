using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class wallSizeController : MonoBehaviour {
    public float speed;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void WallPosition(string axis, float value)
    {
        if (axis == "x")
        {
            if (transform.position.x < value)
            {
                transform.position += new Vector3(1f, 0f, 0f) * Time.deltaTime * speed;
            }
            if (transform.position.x > value)
            {
                transform.position -= new Vector3(1f, 0f, 0f) * Time.deltaTime * speed;
            }
        }

        //y
        if (axis == "y")
        {
            if (transform.position.y < value)
            {
                transform.position += new Vector3(0f, 1f, 0f) * Time.deltaTime * speed;
            }
            if (transform.position.y > value)
            {
                transform.position -= new Vector3(0f, 1f, 0f) * Time.deltaTime * speed;
            }
        }

        //z
        if (axis == "z")
        {
            if (transform.position.z < value)
            {
                transform.position += new Vector3(0f, 0f, 1f) * Time.deltaTime * speed;
            }
            if (transform.position.z > value)
            {
                transform.position -= new Vector3(0f, 0f, 1f) * Time.deltaTime * speed;
            }
        }
    }
}
