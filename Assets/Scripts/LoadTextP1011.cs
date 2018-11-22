using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LoadTextP1011 : MonoBehaviour {

    public GameObject preText;
    public GameObject nextText;
    public GameObject textTemplate;

    public string BookAsset;
    private string[] paragraph;

    private GameObject p10;
    public GameObject bug;
    // Use this for initialization
    void Start () {
        bug.SetActive(false);
        preText.SetActive(false);

        paragraph = ((TextAsset)Resources.Load(BookAsset)).text.Split('\n');

        p10 = Instantiate(textTemplate, this.transform);
        p10.GetComponent<Text>().text = paragraph[10] + ". ";
        p10.GetComponent<Text>().alignment = TextAnchor.MiddleCenter;       
    }
	
	// Update is called once per frame
	void Update () {
        preText.SetActive(false);
        bug.SetActive(false);
        checkP11();

        backToFrontText();
    }

    void checkP11()
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
            preText.GetComponent<LoadTextHail>().rollBackCheck(1);
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
