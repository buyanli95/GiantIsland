using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LoadTextTree : MonoBehaviour {
    public GameObject preText;
    public GameObject TextRoot;
    public GameObject textTemplate;

    public GameObject nextText;
    public GameObject bug;

    //effect
    public GameObject BirdTree;

    public string BookAsset;
    private string[] paragraph;
    private string[] sentence;
    // Use this for initialization
    void Start () {
       
        paragraph = ((TextAsset)Resources.Load(BookAsset)).text.Split('\n');
        sentence = paragraph[3].Split('.');

        GameObject obj = Instantiate(textTemplate, this.transform);
        obj.GetComponent<Text>().text = sentence[2]+". "+sentence[3] + ". ";
        obj.GetComponent<Text>().alignment = TextAnchor.MiddleCenter;

    }
	
	// Update is called once per frame
	void Update () {
        bug.SetActive(false);

        preText.SetActive(false);
        BirdTree.SetActive(true);

        GiantBack();
        backToFrontText();
    }

    void GiantBack()
    {
        if (OVRInput.GetUp(OVRInput.Button.PrimaryHandTrigger))
        {
            GameObject g = TextRoot.transform.Find("Spot-GiantBack").gameObject;
            g.SetActive(true);
        }
    }


    // go back to the front Texts
    void backToFrontText()
    {
        if (OVRInput.GetUp(OVRInput.Button.PrimaryIndexTrigger))
        {
            //disable current effect
            BirdTree.SetActive(false);
            preText.SetActive(true);
            preText.GetComponent<LoadTextFlower>().rollBackCheck(1);
        }
    }

    //actived by its next Text, destroy the next Text, and enable current effects
    public void rollBackCheck(int flag)
    {
        if (flag == 1)
        {
            nextText.SetActive(false);
            BirdTree.SetActive(true);
        }
    }
}
