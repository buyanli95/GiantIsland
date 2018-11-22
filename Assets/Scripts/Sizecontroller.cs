using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sizecontroller : MonoBehaviour {
    public int grassScale;
	// Use this for initialization
	void Start () {
        //int ran = Random.Range(0, 4);
        //if (ran == 0)
        //{
        //transform.position = new Vector3(transform.position.x, Random.Range(-0.5f, 0f), transform.position.z);
        //}

        grassScale += Random.Range(-15, 10);
    }

    // Update is called once per frame
    void Update () {
        Vector3 size = new Vector3(10f , 10f, 10f);
        if (transform.localScale.x < grassScale)
        {
            transform.localScale += size * Time.deltaTime* Random.Range(-2f,10f);
        }

        transform.Rotate(0, Random.Range(-2f, 2f)*Time.deltaTime, 0, 0);
    }
}
