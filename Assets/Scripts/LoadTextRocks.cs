using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LoadTextRocks : MonoBehaviour {
    public GameObject cue;
    public GameObject footPrintCue;
    public GameObject preText;

    public GameObject TextRoot;
    public GameObject textTemplate;

    public string BookAsset;
    private string[] paragraph;

    public GameObject rocks;

    private GameObject part1;
    private GameObject part2;
    private int check;

    public GameObject nextText;
    public GameObject bug;

    // Use this for initialization
    void Start () {
        check = 0;
        preText.GetComponent<LoadTextBoard>().enabled = false;
        cue.SetActive(false);
        footPrintCue.transform.position -= new Vector3(0f, 20f, 0f);
        
        paragraph = ((TextAsset)Resources.Load(BookAsset)).text.Split('\n');
 
        part1 = Instantiate(textTemplate, this.transform);
        part1.GetComponent<Text>().text = paragraph[7];
        part1.GetComponent<Text>().alignment = TextAnchor.MiddleCenter;

        check = 1;
    }
	
	// Update is called once per frame
	void Update () {
        bug.SetActive(false);
        preText.GetComponent<LoadTextBoard>().enabled = false;
        //rocks.SetActive(true);
 
        //part1
        if (check == 1) {
             
            part1.SetActive(true);
            
            if (OVRInput.GetUp(OVRInput.Button.PrimaryHandTrigger))
            {
                part1.SetActive(false);

                if(!part2)
                {
                    part2 = Instantiate(textTemplate, this.transform);
                    part2.GetComponent<Text>().text = paragraph[8];
                    part2.GetComponent<Text>().alignment = TextAnchor.MiddleCenter;
                }else if(part2.active == false){
                    part2.SetActive(true);
                }
                check = 2;
            }
            backToFrontText();
        }
        //part2
        else if(check == 2 && OVRInput.GetUp(OVRInput.Button.PrimaryIndexTrigger)) // from part2 back to part1
        {
            //part1.SetActive(true);
            part2.SetActive(false);
            check = 1;
        }
        //next Text
        else if (OVRInput.GetUp(OVRInput.Button.PrimaryHandTrigger) && (check == 2))
        {
            GameObject g = TextRoot.transform.Find("Spot-seasons").gameObject;
            g.SetActive(true);
        }
    }

    // go back to the front Texts
    void backToFrontText()
    {
        if (OVRInput.GetUp(OVRInput.Button.PrimaryIndexTrigger))
        {
            rocks.SetActive(false);
            preText.GetComponent<LoadTextBoard>().enabled = true;
            preText.GetComponent<LoadTextBoard>().rollBackCheck(1);
        }
    }

    //actived by its next Text, destroy the next Text, and enable current effects
    public void rollBackCheck(int flag)
    {
        if (flag == 1)
        {
            nextText.SetActive(false);
            rocks.SetActive(true);
        }
    }
}
