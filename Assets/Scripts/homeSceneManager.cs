using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class homeSceneManager : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

        //back to home space
        if (OVRInput.GetUp(OVRInput.Button.Start))
        {
            SceneManager.LoadScene(0, LoadSceneMode.Single);
        }
    }
}
