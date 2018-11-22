using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Video;

public class LoadTextChildrenBack : MonoBehaviour {

    public GameObject island;
    private VideoPlayer vp;

    public GameObject preText;
    public GameObject nextText;
    public GameObject textTemplate;

    public string BookAsset;
    private string[] paragraph;

    private GameObject part1;
    private GameObject part2;
    private GameObject part3;
    //private GameObject part4;
    private int check;

    public GameObject trees;
    public GameObject flowerLand;
    public GameObject bushes;
    public GameObject wind;
    public GameObject Boy;
    public GameObject plane;

    public GameObject bug;
    // Use this for initialization
    void Start () {
        check = 0;
        preText.SetActive(false);

        vp = island.GetComponent<VideoPlayer>();

        paragraph = ((TextAsset)Resources.Load(BookAsset)).text.Split('\n');

        part1 = Instantiate(textTemplate, this.transform);
        part1.GetComponent<Text>().text = paragraph[14].Split('.')[0] + ". " + paragraph[14].Split('.')[1] + ". " + paragraph[14].Split('.')[2];
        part1.GetComponent<Text>().alignment = TextAnchor.MiddleCenter;

        check = 1;
    }
	
	// Update is called once per frame
	void Update () {
        preText.SetActive(false);
        bug.SetActive(false);

        //effects
        vp.enabled = false;
        trees.GetComponent<LeavesFallController>().enabled = false;
        trees.GetComponent<LeavesGrowController>().enabled = true;
        bushes.SetActive(true);

        if((wind.GetComponent<WindZone>().windTurbulence > 3))
        {
            wind.GetComponent<WindZone>().windTurbulence -= Time.deltaTime;
        }

        //p14 part2
        if (check == 1)
        {
            part1.SetActive(true);
            if (OVRInput.GetUp(OVRInput.Button.PrimaryHandTrigger))
            {
                part1.SetActive(false);

                if (!part2)
                {
                    part2 = Instantiate(textTemplate, this.transform);
                    part2.GetComponent<Text>().text = paragraph[14].Split('.')[3] + ". " + paragraph[14].Split('.')[4] + ". " + paragraph[14].Split('.')[5] + ". " + paragraph[14].Split('.')[6] + ". ";
                    part2.GetComponent<Text>().alignment = TextAnchor.MiddleCenter;
                } else if (part2.active == false)
                {
                    part2.SetActive(true);
                }
                check = 2;
                flowerLand.SetActive(true);
            }
            backToFrontText();
        }

        //part2 back to part1
        else if (check == 2 && OVRInput.GetUp(OVRInput.Button.PrimaryIndexTrigger))
        {
            part2.SetActive(false);
            check = 1;
        }

        else if (check == 2) //boy
        {
            part2.SetActive(true);
            if (OVRInput.GetUp(OVRInput.Button.PrimaryHandTrigger))
            {
                part2.SetActive(false);
                if (!part3)
                {
                    part3 = Instantiate(textTemplate, this.transform);
                    part3.GetComponent<Text>().text = paragraph[14].Split('.')[7] + ". " + paragraph[14].Split('.')[8] + ". " + paragraph[14].Split('.')[9] + ". "; // + " " + paragraph[14].Split('.')[10] + " " + paragraph[14].Split('.')[11];
                    part3.GetComponent<Text>().alignment = TextAnchor.MiddleCenter;
                }else if(part3.active == false)
                {
                    part3.SetActive(true);
                }
                plane.SetActive(true);
                Boy.SetActive(true);
                check = 3;
            }     
        }

        //part3 back to part2
        else if (check == 3 && OVRInput.GetUp(OVRInput.Button.PrimaryIndexTrigger))
        {
            part3.SetActive(false);
            check = 2;
        }

        else if (OVRInput.GetUp(OVRInput.Button.PrimaryHandTrigger) && check == 3)
        {
            nextText.SetActive(true);
        }

    }

    // go back to the front Texts
    void backToFrontText()
    {
        if (OVRInput.GetUp(OVRInput.Button.PrimaryIndexTrigger))
        {
            flowerLand.SetActive(false);
            Boy.SetActive(false);
            preText.SetActive(true);
            print("roll back");
            preText.GetComponent<LoadTextP12>().rollBackCheck(1);
        }
    }

    //actived by its next Text, destroy the next Text, and enable current effects
    public void rollBackCheck(int flag)
    {
        if (flag == 1)
        {
            nextText.SetActive(false);
            flowerLand.SetActive(true);
            Boy.SetActive(true);
        }
    }
}
