using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LoadTextWall : MonoBehaviour {
    public GameObject preText;
    public GameObject TextRoot;
    public GameObject textTemplate;
 
    public string BookAsset;
    private string[] paragraph;
    private string[] sentence;

    public GameObject wall;

    public GameObject nextText;
    public GameObject bug;

    // Use this for initialization
    void Start () {
        preText.SetActive(false);

        paragraph = ((TextAsset)Resources.Load(BookAsset)).text.Split('\n');
        sentence = paragraph[5].Split('.');

        GameObject obj = Instantiate(textTemplate, this.transform);
        //sentence[1] = sentence[1].Replace("\"", " ").Trim();
        obj.GetComponent<Text>().text = sentence[1] + ". ";
        obj.GetComponent<Text>().alignment = TextAnchor.MiddleCenter;

    }
	
	// Update is called once per frame
	void Update () {
        preText.SetActive(false);
        bug.SetActive(false);

        checkWallandNext();

        backToFrontText();
    }

    void checkWallandNext()
    {
        if (OVRInput.GetUp(OVRInput.Button.PrimaryHandTrigger))
        {
            wall.SetActive(true); //wall up
        }
    }

    // go back to the front Texts
    void backToFrontText()
    {
        if (OVRInput.GetUp(OVRInput.Button.PrimaryIndexTrigger))
        {
            wall.SetActive(false);
            preText.SetActive(true);
            preText.GetComponent<LoadTextGiantRoar>().rollBackCheck(1);
        }
    }

    //actived by its next Text, destroy the next Text, and enable current effects
    public void rollBackCheck(int flag)
    {
        if (flag == 1)
        {
            nextText.SetActive(false);
            wall.SetActive(false);
            wall.GetComponent<footPrintController>().enabled = true;
        }
    }
}
