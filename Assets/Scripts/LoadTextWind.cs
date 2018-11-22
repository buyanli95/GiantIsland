using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LoadTextWind : MonoBehaviour {
    public GameObject preText;
    public GameObject nextText;
    public GameObject textTemplate;

    public string BookAsset;
    private string[] paragraph;

    public GameObject wind;
    public GameObject bug;
    // Use this for initialization
    void Start () {
        preText.SetActive(false);
        bug.SetActive(false);

        paragraph = ((TextAsset)Resources.Load(BookAsset)).text.Split('\n');

        GameObject obj = Instantiate(textTemplate, this.transform);
        obj.GetComponent<Text>().text = paragraph[9].Split('.')[7] + ". " + paragraph[9].Split('.')[8] + ". " + paragraph[9].Split('.')[9] + ". ";
        print("rock text: " + obj.GetComponent<Text>().text);
        obj.GetComponent<Text>().alignment = TextAnchor.MiddleCenter;

        
    }
	
	// Update is called once per frame
	void Update () {
        bug.SetActive(false);
        preText.SetActive(false);
        wind.SetActive(true);

        checkHail();
        backToFrontText();
    }

    void checkHail()
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
            wind.SetActive(false);
            preText.SetActive(true);
            preText.GetComponent<LoadTextFrostSnow>().rollBackCheck(1);
        }
    }

    //actived by its next Text, destroy the next Text, and enable current effects
    public void rollBackCheck(int flag)
    {
        if (flag == 1)
        {
            nextText.SetActive(false);
            wind.SetActive(true);
        }
    }
}
