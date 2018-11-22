using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LoadText : MonoBehaviour {

    //keep txt file content
    private string myTXT;
    // gameobject: text
    public Text textToChange;

	// Use this for initialization
	void Start () {
        myTXT = ((TextAsset)Resources.Load("story")).text;
	}
	
	// Update is called once per frame
	void Update () {
        textToChange.text = myTXT;
	}
}
