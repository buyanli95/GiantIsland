using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class flowerAnimation : MonoBehaviour {
    public GameObject[] flowerList;
    public int amoutMax;
    private int Amount;

    public float xmin;
    public float xmax;
    public float ymin;
    public float ymax;
    public float zmin;
    public float zmax;

    // Use this for initialization
    void Start () {
        Amount = 0;
	}
	
	// Update is called once per frame
	void Update () {
        if (Amount < amoutMax)
        {
            InvokeRepeating("Newobj", 1, 1);
        }
        else
        {
            CancelInvoke();
        }
    }

    void Newobj()
    {
        int f = Random.Range(0, 14);
        //launchPosition.position = new Vector3(Random.Range(-1f, 1f), 0, Random.Range(-1f, 1f));
        GameObject one = Instantiate(flowerList[f], this.transform);
        //one.transform.position = new Vector3(Random.Range(-400f, 400f), flowerList[f].transform.position.y, Random.Range(-50f, 300f));
        one.transform.position = new Vector3(Random.Range(xmin, xmax), Random.Range(ymin, ymax), Random.Range(zmin, zmax));
        one.SetActive(true);
        Amount++;
    }
}
