using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LoadTextGiantRoar : MonoBehaviour {
    public GameObject preText;
    public GameObject TextRoot;
    public GameObject textTemplate;

    //public GameObject birds;

    public string BookAsset;
    private string[] paragraph;
    private string[] sentence;
    private string[] sentence2;

    public GameObject roar;

    public GameObject nextText;

    // Use this for initialization
    void Start () {
        preText.SetActive(false);

        paragraph = ((TextAsset)Resources.Load(BookAsset)).text.Split('\n');
        sentence = paragraph[4].Split('.');
        sentence2 = paragraph[5].Split('.');

        GameObject obj = Instantiate(textTemplate, this.transform);
        obj.GetComponent<Text>().text = sentence[4] + ". " + "\n" + sentence2[0] + ". " + sentence2[1].Split(' ')[0];
        obj.GetComponent<Text>().alignment = TextAnchor.MiddleCenter;

        
    }
	
	// Update is called once per frame
	void Update () {
        preText.SetActive(false);
        roar.SetActive(true);

        checkWall();

        backToFrontText();
    }

    void checkWall()
    {
        if (OVRInput.GetUp(OVRInput.Button.PrimaryHandTrigger))
        {
            GameObject g = TextRoot.transform.Find("Spot-Wall").gameObject;
            g.SetActive(true);
        }
    }

    // go back to the front Texts
    void backToFrontText()
    {
        if (OVRInput.GetUp(OVRInput.Button.PrimaryIndexTrigger))
        {
            roar.SetActive(false);
            preText.SetActive(true);
            preText.GetComponent<LoadTextGiantBack2>().rollBackCheck(1);
        }
    }

    //actived by its next Text, destroy the next Text, and enable current effects
    public void rollBackCheck(int flag)
    {
        if (flag == 1)
        {
            nextText.SetActive(false);
            roar.SetActive(true);
        }
    }
}
