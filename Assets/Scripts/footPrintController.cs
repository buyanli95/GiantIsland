using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class footPrintController : MonoBehaviour {
    public GameObject Pre_footprint;
    public GameObject Next_footprint;
	// Use this for initialization
	void Start () {
        StartCoroutine(waithere());
    }

    IEnumerator waithere()
    {
        yield return new WaitForSeconds(1);
        Next_footprint.SetActive(true);
    }
}
