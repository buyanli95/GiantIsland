using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LoadText34 : MonoBehaviour {

    public GameObject preText;
    public GameObject TextRoot;
    public GameObject textTemplate;

    public string BookAsset;
    private string[] paragraph;

    //public GameObject trees;
    public GameObject birds;
    public GameObject bushes;
    public GameObject flowers;

    public GameObject nextText;
    public GameObject bug;

    // Use this for initialization
    void Start () {
        preText.SetActive(false);

        paragraph = ((TextAsset)Resources.Load(BookAsset)).text.Split('\n');

        GameObject obj = Instantiate(textTemplate, this.transform);
        obj.GetComponent<Text>().text = paragraph[9].Split('.')[2] + "." + paragraph[9].Split('.')[3] + ". ";
        print("rock text: " + obj.GetComponent<Text>().text);
        obj.GetComponent<Text>().alignment = TextAnchor.MiddleCenter;
    }
	
	// Update is called once per frame
	void Update () {
        preText.SetActive(false);
        bug.SetActive(false);

        flowers.SetActive(false);
        birds.GetComponent<AudioBird>().enabled = false;
        birds.GetComponent<audioBirdsVolumnDown>().enabled = true;

        backToFrontText();

        if (bushes.transform.position.y > -150)
        {
            bushes.transform.position -= new Vector3(0f, 10f, 0f) * Time.deltaTime;
        }
        else
        {
            Destroy(bushes);
        } 
        checkFrostSnow();
	}

    void checkFrostSnow()
    {
        if (OVRInput.GetUp(OVRInput.Button.PrimaryHandTrigger))
        {
            GameObject g = TextRoot.transform.Find("Spot-FrostSnow").gameObject;
            g.SetActive(true);
        }
    }

    // go back to the front Texts
    void backToFrontText()
    {
        if (OVRInput.GetUp(OVRInput.Button.PrimaryIndexTrigger))
        {
            flowers.SetActive(true);
            birds.GetComponent<AudioBird>().enabled = true;
            birds.GetComponent<audioBirdsVolumnDown>().enabled = false;

            preText.SetActive(true);
            preText.GetComponent<LoadTextSeason>().rollBackCheck(1);
        }
    }

    //actived by its next Text, destroy the next Text, and enable current effects
    public void rollBackCheck(int flag)
    {
        if (flag == 1)
        {
            nextText.SetActive(false);

            flowers.SetActive(false);
            birds.GetComponent<AudioBird>().enabled = false;
            birds.GetComponent<audioBirdsVolumnDown>().enabled = true;
        }
    }
}
