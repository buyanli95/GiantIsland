using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandTriggerGuide : MonoBehaviour {
    public GameObject IndexTrigger;
    public GameObject Home;

    private bool rollbacksign;
	// Use this for initialization
	void Start () {
        rollbacksign = false;
	}
	
	// Update is called once per frame
	void Update () {
        if (rollbacksign == false && OVRInput.GetUp(OVRInput.Button.PrimaryHandTrigger))
        {
            IndexTrigger.SetActive(true);
        }else if(rollbacksign == true && OVRInput.GetUp(OVRInput.Button.PrimaryHandTrigger))
        {
            Home.SetActive(true);
        }

    }

    //actived by its next Text, destroy the next Text, and enable current effects
    public void rollBackCheck(int flag)
    {
        if (flag == 1)
        {
            rollbacksign = true;
            IndexTrigger.SetActive(false);
            this.GetComponent<TextMesh>().text = "Well Done!"+'\n'+ "Go Next and Start Reading!";
            if (OVRInput.GetUp(OVRInput.Button.PrimaryHandTrigger))
            {
                Home.SetActive(true);
            }
        }
    }
}
