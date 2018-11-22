using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LoadTextHail : MonoBehaviour {
    public GameObject preText;
    public GameObject nextText;
    public GameObject textTemplate;

    public string BookAsset;
    private string[] paragraph;

    public GameObject hail;
    // Use this for initialization
    void Start () {
        paragraph = ((TextAsset)Resources.Load(BookAsset)).text.Split('\n');

        GameObject obj = Instantiate(textTemplate, this.transform);
        obj.GetComponent<Text>().text = paragraph[9].Split('.')[10] + ". " + paragraph[9].Split('.')[11] + ". " + paragraph[9].Split('.')[12] + ". ";
        print("rock text: " + obj.GetComponent<Text>().text);
        obj.GetComponent<Text>().alignment = TextAnchor.MiddleCenter;
    }
	
	// Update is called once per frame
	void Update () {
        preText.SetActive(false);
        hail.SetActive(true);

        check10_1();
        backToFrontText();
    }

    void check10_1()
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
            hail.SetActive(false);
            preText.SetActive(true);
            preText.GetComponent<LoadTextWind>().rollBackCheck(1);
        }
    }

    //actived by its next Text, destroy the next Text, and enable current effects
    public void rollBackCheck(int flag)
    {
        if (flag == 1)
        {
            nextText.SetActive(false);
            hail.SetActive(true);
        }
    }
}
