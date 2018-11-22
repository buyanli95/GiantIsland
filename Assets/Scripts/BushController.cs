using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BushController : MonoBehaviour {
    public GameObject template;
    public Transform launchPosition;

    //public GameObject next;

    public float xmin;
    public float xmax;
    public float ymin;
    public float ymax;
    public float zmin;
    public float zmax;

    private int grassSize;
    public int grassSizeMax;
	// Use this for initialization
	void Start () {
        grassSize = 0;
	}
	
	// Update is called once per frame
	void Update () {

        if(grassSize < grassSizeMax){
            InvokeRepeating("Newobj", 1, 1);
        }else{
            CancelInvoke();
        }
    }

    void Newobj()
    {
        //launchPosition.position = new Vector3(Random.Range(-1f, 1f), 0, Random.Range(-1f, 1f));
        GameObject one = Instantiate(template, launchPosition);
        //one.transform.position = new Vector3(Random.Range(-500f, 500f), template.transform.position.y, Random.Range(-100f, 500f));
        one.transform.position = new Vector3(Random.Range(xmin, xmax), Random.Range(ymin, ymax), Random.Range(zmin, zmax));
        one.SetActive(true);
        grassSize++;
    }
}
