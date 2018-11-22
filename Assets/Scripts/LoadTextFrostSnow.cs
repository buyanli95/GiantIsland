using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LoadTextFrostSnow : MonoBehaviour {

    public GameObject preText;
    public GameObject nextText;
    public GameObject textTemplate;

    public string BookAsset;
    private string[] paragraph;

    // Use this for initialization
    void Start () {
        preText.SetActive(false);

        paragraph = ((TextAsset)Resources.Load(BookAsset)).text.Split('\n');

        GameObject obj = Instantiate(textTemplate, this.transform);
        obj.GetComponent<Text>().text = paragraph[9].Split('.')[4] + ". " + paragraph[9].Split('.')[5] + ". "+ paragraph[9].Split('.')[6] + ". ";
        print("rock text: " + obj.GetComponent<Text>().text);
        obj.GetComponent<Text>().alignment = TextAnchor.MiddleCenter;
    }
	
	// Update is called once per frame
	void Update () {
        preText.SetActive(false);
        checkWind();

        backToFrontText();
    }

    void checkWind()
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
            preText.SetActive(true);
            preText.GetComponent<LoadText34>().rollBackCheck(1);
        }
    }

    //actived by its next Text, destroy the next Text, and enable current effects
    public void rollBackCheck(int flag)
    {
        if (flag == 1)
        {
            nextText.SetActive(false);
        }
    }
}
