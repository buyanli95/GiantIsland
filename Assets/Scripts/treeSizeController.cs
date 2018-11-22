using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class treeSizeController : MonoBehaviour {

    // Use this for initialization
    void Start () {
        //int ran = Random.Range(0, 4);
        //if (ran == 0)
        //{
        //    transform.position = new Vector3(transform.position.x, Random.Range(-3f, 0f), transform.position.z);
        //}
    }
	
	// Update is called once per frame
	void Update () {
        Vector3 size = new Vector3(0.2f, 0.2f, 0.2f);
        if (transform.localScale.x < 25)
        {
            transform.localScale += size * Time.deltaTime * Random.Range(2f, 10f);
        }
    }
}
