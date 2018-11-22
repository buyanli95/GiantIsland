using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IndexTriggerGuide : MonoBehaviour {
    public GameObject HandTrigger;
    //public GameObject BookHome;
	// Use this for initialization
	void Start () {
        HandTrigger.SetActive(false);
	}
	
	// Update is called once per frame
	void Update () {
        if (OVRInput.GetUp(OVRInput.Button.PrimaryIndexTrigger))
        {
            HandTrigger.SetActive(true);
            HandTrigger.GetComponent<HandTriggerGuide>().rollBackCheck(1);
        }

    }
}
