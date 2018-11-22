using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Video;

public class LoadTextSeason : MonoBehaviour {
    public GameObject preText;
    public GameObject TextRoot;
    public GameObject textTemplate;

    public string BookAsset;
    private string[] paragraph;

    public GameObject island;
    private VideoPlayer[] vps;
    public GameObject bushes;
    public GameObject flowers;
    public GameObject trees;

    public GameObject nextText;

    // Use this for initialization
    void Start () {

        preText.SetActive(false);

        paragraph = ((TextAsset)Resources.Load(BookAsset)).text.Split('\n');

        GameObject obj = Instantiate(textTemplate, this.transform);
        obj.GetComponent<Text>().text = paragraph[9].Split('.')[0] + ". " + paragraph[9].Split('.')[1] + ". ";
        print("rock text: " + obj.GetComponent<Text>().text);
        obj.GetComponent<Text>().alignment = TextAnchor.MiddleCenter;

        vps = island.GetComponents<VideoPlayer>();
        foreach(VideoPlayer vp in vps)
        {
            vp.enabled = !vp.enabled;
        }

        
    }
	
	// Update is called once per frame
	void Update () {
        preText.SetActive(false);
        bushes.SetActive(true);
        flowers.SetActive(true);
        trees.GetComponent<LeavesFallController>().enabled = true;

        check34();

        backToFrontText();
    }

    void check34()
    {
        if (OVRInput.GetUp(OVRInput.Button.PrimaryHandTrigger))
        {
            GameObject g = TextRoot.transform.Find("Spot-34").gameObject;
            g.SetActive(true);
        }
    }

    // go back to the front Texts
    void backToFrontText()
    {
        if (OVRInput.GetUp(OVRInput.Button.PrimaryIndexTrigger))
        {
            bushes.SetActive(false);
            flowers.SetActive(false);
            trees.GetComponent<LeavesFallController>().enabled = false;
            trees.GetComponent<LeavesGrowController>().enabled = true;

            preText.SetActive(true);
            preText.GetComponent<LoadTextRocks>().rollBackCheck(1);
        }
    }

    //actived by its next Text, destroy the next Text, and enable current effects
    public void rollBackCheck(int flag)
    {
        if (flag == 1)
        {
            nextText.SetActive(false);
            bushes.SetActive(true);
            flowers.SetActive(true);
            trees.GetComponent<LeavesGrowController>().enabled = false;
            trees.GetComponent<LeavesFallController>().enabled = true;
        }
    }
}
