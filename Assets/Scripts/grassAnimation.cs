using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class grassAnimation : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        Vector3 size = new Vector3(5f, 5f, 5f);
        Vector3 height = new Vector3(0, 400f, 0);
        if (transform.localScale.x < 20)
        {
            transform.localScale += size * Time.deltaTime;
        }
        if (transform.position.y < -30)
        {
            transform.position += height * Time.deltaTime;
        }
    }
}
