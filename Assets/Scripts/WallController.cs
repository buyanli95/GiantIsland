using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WallController : MonoBehaviour {
    public GameObject noticeBoard;
    public Light mainLt;
    public Light afternoonLt;
    public Light grassLight;
    public GameObject footPrintCue;
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void FixedUpdate () {
        if (transform.position.z < -300)
        {
            transform.position += new Vector3(0, 0, 200f * Time.deltaTime);
            footPrintCue.SetActive(false);
        }
        else if( transform.position.y >= -300)
        {
            noticeBoard.SetActive(true);
            footPrintCue.SetActive(true);
            //lt.GetComponent<AfternoonEffect>().enabled = false;

            afternoonLt.enabled = false;

            if(mainLt.intensity > 0)
            {
                mainLt.intensity -= Time.deltaTime/5;
            }

            if (grassLight.intensity > 0)
            {
                grassLight.intensity -= Time.deltaTime / 5;
            }
        }
    }

   
}
