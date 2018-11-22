using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class stoneController : MonoBehaviour {
    public Transform launchPosition;
    public GameObject[] stoneTypes;
    private int stones;
	// Use this for initialization
	void Start () {
        stones = 20;
        //stoneTypes = GetComponentsInChildren<Transform>();
    }
	
	// Update is called once per frame
	void Update () {

        if (stones > 0)
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
        int stoneNo = Random.Range(0, stoneTypes.Length);
        GameObject one = Instantiate(stoneTypes[stoneNo], launchPosition);
        one.transform.position = new Vector3(Random.Range(-120f, 40f), launchPosition.position.y, Random.Range(-250f, 200f));
        one.SetActive(true);
        stones--;
    }
}
