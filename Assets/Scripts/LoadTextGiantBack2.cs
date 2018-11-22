using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LoadTextGiantBack2 : MonoBehaviour {
    public GameObject preText;
    public GameObject TextRoot;
    public GameObject textTemplate;

    public string BookAsset;
    private string[] paragraph;
    private string[] sentence;

    public GameObject nextText;
    public GameObject bug;

    // Use this for initialization
    void Start () {
        preText.SetActive(false);

        paragraph = ((TextAsset)Resources.Load(BookAsset)).text.Split('\n');
        sentence = paragraph[4].Split('.');

        GameObject obj = Instantiate(textTemplate, this.transform);
        obj.GetComponent<Text>().text = sentence[2] + ". " + sentence[3] + ". ";
        obj.GetComponent<Text>().alignment = TextAnchor.MiddleCenter;
    }
	
	// Update is called once per frame
	void Update () {
        preText.SetActive(false);
        bug.SetActive(false);

        checkGiantRoar();

        backToFrontText();
    }

    void checkGiantRoar()
    {
        if (OVRInput.GetUp(OVRInput.Button.PrimaryHandTrigger))
        {
            GameObject g = TextRoot.transform.Find("Spot-GiantRoar").gameObject;
            g.SetActive(true);
        }
    }

    // go back to the front Texts
    void backToFrontText()
    {
        if (OVRInput.GetUp(OVRInput.Button.PrimaryIndexTrigger))
        {
            preText.SetActive(true);
            preText.GetComponent<LoadTextGiantBack>().rollBackCheck(1);
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
