using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LoadTextGiantBack : MonoBehaviour {
    public GameObject preText;
    public GameObject TextRoot;
    public GameObject textTemplate;

    public GameObject nextText;

    public string BookAsset;
    private string[] paragraph;
    private string[] sentence;

    //effect
    public GameObject GiantVibration;
    // Use this for initialization
    void Start () {

        preText.SetActive(false);

        paragraph = ((TextAsset)Resources.Load(BookAsset)).text.Split('\n');
        sentence = paragraph[4].Split('.');

        GameObject obj = Instantiate(textTemplate, this.transform);
        obj.GetComponent<Text>().text = sentence[0] + ". " + sentence[1] + ". ";
        obj.GetComponent<Text>().alignment = TextAnchor.MiddleCenter;

        GiantVibration.SetActive(true);
    }
	
	// Update is called once per frame
	void Update () {

        GiantVibration.SetActive(true);
        preText.SetActive(false);
        GiantRoar();

        backToFrontText();
    }

    void GiantRoar()
    {
        if (OVRInput.GetUp(OVRInput.Button.PrimaryHandTrigger))
        {
            GameObject g = TextRoot.transform.Find("Spot-GiantBack2").gameObject;
            g.SetActive(true);
        }
    }

    // go back to the front Texts
    void backToFrontText()
    {
        if (OVRInput.GetUp(OVRInput.Button.PrimaryIndexTrigger))
        {
            GiantVibration.SetActive(false);
            preText.SetActive(true);
            preText.GetComponent<LoadTextTree>().rollBackCheck(1);
        }
    }

    //actived by its next Text, destroy the next Text, and enable current effects
    public void rollBackCheck(int flag)
    {
        if (flag == 1)
        {
            nextText.SetActive(false);
            GiantVibration.SetActive(true);
        }
    }

}
