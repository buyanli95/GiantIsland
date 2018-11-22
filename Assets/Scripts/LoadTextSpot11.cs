using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LoadTextSpot11 : MonoBehaviour {
    public GameObject preText;
    public GameObject nextText;
    public GameObject textTemplate;

    public string BookAsset;
    private string[] paragraph;

    public GameObject fruits;
    // Use this for initialization
    void Start () {
        preText.SetActive(false);

        paragraph = ((TextAsset)Resources.Load(BookAsset)).text.Split('\n');

        GameObject obj = Instantiate(textTemplate, this.transform);
        obj.GetComponent<Text>().text = paragraph[11] + ". ";
        obj.GetComponent<Text>().alignment = TextAnchor.MiddleCenter;
        
    }
	
	// Update is called once per frame
	void Update () {
        preText.SetActive(false);
        fruits.SetActive(true);

        checkP12();

        backToFrontText();
    }

    void checkP12()
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
            fruits.SetActive(false);
            preText.SetActive(true);
            preText.GetComponent<LoadTextP1011>().rollBackCheck(1);
        }
    }

    //actived by its next Text, destroy the next Text, and enable current effects
    public void rollBackCheck(int flag)
    {
        if (flag == 1)
        {
            nextText.SetActive(false);
            fruits.SetActive(true);
        }
    }
}
