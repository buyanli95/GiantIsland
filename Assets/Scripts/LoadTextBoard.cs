using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadTextBoard : MonoBehaviour {

    public GameObject preText;
    public GameObject nextText;

    public GameObject cueForWallReading;
    public GameObject footprints;
    // Use this for initialization
    void Start () {
        preText.SetActive(false);
        cueForWallReading.SetActive(true);
	}
	
	// Update is called once per frame
	void Update () {
        preText.SetActive(false);
        //cueForWallReading.SetActive(true);

        checkRocks();

        backToFrontText();
    }

    void checkRocks()
    {
        if (OVRInput.GetUp(OVRInput.Button.PrimaryHandTrigger))
        {
            nextText.SetActive(true);
        }
    }

    // go back to the front Texts
    void backToFrontText()
    {
        if (OVRInput.GetUp(OVRInput.Button.PrimaryIndexTrigger))
        {
            //CurrentEffect.SetActive(false);
            cueForWallReading.SetActive(false);
            footprints.SetActive(false);

            preText.SetActive(true);
            preText.GetComponent<LoadTextWall>().rollBackCheck(1);
        }
    }

    //actived by its next Text, destroy the next Text, and enable current effects
    public void rollBackCheck(int flag)
    {
        if (flag == 1)
        {
            nextText.SetActive(false);
            //CurrentEffect.SetActive(true);
        }
    }
}
