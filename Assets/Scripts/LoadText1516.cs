using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LoadText1516 : MonoBehaviour {

    public GameObject preText;
    public GameObject nextText;
    public GameObject textTemplate;

    public string BookAsset;
    private string[] paragraph;

    private GameObject part1;
    private GameObject part2;
    private int check;

    public GameObject wall;
    public GameObject board;

    //disable objects
    public GameObject bush2;
    public GameObject flower2;
    public GameObject wind;
    public GameObject rocks;

    public GameObject bug;
    // Use this for initialization
    void Start () {
        check = 0;
        preText.SetActive(false);
        bug.SetActive(false);

        paragraph = ((TextAsset)Resources.Load(BookAsset)).text.Split('\n');

        part1 = Instantiate(textTemplate, this.transform);
        part1.GetComponent<Text>().text = paragraph[15] + ".";
        part1.GetComponent<Text>().alignment = TextAnchor.MiddleCenter;

        check = 1;
    }
	
	// Update is called once per frame
	void Update () {
        preText.SetActive(false);
        bug.SetActive(false);

        //effects
        wall.GetComponent<WallController>().enabled = false;
        wall.GetComponent<wallSizeController>().WallPosition("z", -680f);
        board.GetComponent<wallSizeController>().WallPosition("x", -450);

        //p16 
        if (check == 1)
        {
            part1.SetActive(true);
            if (OVRInput.GetUp(OVRInput.Button.PrimaryHandTrigger))
            {
                part1.SetActive(false);

                if (!part2)
                {
                    part2 = Instantiate(textTemplate, this.transform);
                    part2.GetComponent<Text>().text = paragraph[16] + ".";
                    part2.GetComponent<Text>().alignment = TextAnchor.MiddleCenter;
                }else if(part2.active == false)
                {
                    part2.SetActive(true);
                }

                check = 2;
            }
            backToFrontText();
        }

        //part2 back to part1
        else if (check == 2 && OVRInput.GetUp(OVRInput.Button.PrimaryIndexTrigger))
        {
            part2.SetActive(false);
            check = 1;
        }

        else if (OVRInput.GetUp(OVRInput.Button.PrimaryHandTrigger) && check == 2)
        {
            nextText.SetActive(true);

            wall.SetActive(false);
            board.SetActive(false);
            bush2.SetActive(false);
            flower2.SetActive(false);
            wind.GetComponent<WindOff>().enabled = true;
            rocks.SetActive(false);
        } 
    }

    // go back to the front Texts
    void backToFrontText()
    {
        if (OVRInput.GetUp(OVRInput.Button.PrimaryIndexTrigger))
        {
            wall.SetActive(true);
            wall.GetComponent<WallController>().enabled = true;
            wall.GetComponent<wallSizeController>().enabled = false;

            preText.SetActive(true);
            preText.GetComponent<LoadTextChildrenBack>().rollBackCheck(1);
            preText.GetComponent<Text>().material.color = Color.black;
        }
    }

    //actived by its next Text, destroy the next Text, and enable current effects
    public void rollBackCheck(int flag)
    {
        if (flag == 1)
        {
            nextText.SetActive(false);
            //CurrentEffect.SetActive(true);
        }
    }
}
