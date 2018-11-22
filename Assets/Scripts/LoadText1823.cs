using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LoadText1823 : MonoBehaviour {

    public GameObject preText;
    public GameObject nextText;
    public GameObject textTemplate;

    public string BookAsset;
    private string[] paragraph;

    private GameObject part1;
    private GameObject part2;
    private GameObject part3;
    private GameObject part4;
    private GameObject part5;
    private GameObject part6;

    private int check;

    public GameObject bug;

    // Use this for initialization
    void Start () {
        check = 0;
        preText.SetActive(false);
        bug.SetActive(false);

        paragraph = ((TextAsset)Resources.Load(BookAsset)).text.Split('\n');

        part1 = Instantiate(textTemplate, this.transform);
        part1.GetComponent<Text>().text = paragraph[18];
        part1.GetComponent<Text>().alignment = TextAnchor.MiddleCenter;

        check = 1;
    }
	
	// Update is called once per frame
	void Update () {
        preText.SetActive(false);
        bug.SetActive(false);

        if (check == 1)
        {
            part1.SetActive(true);
            if (OVRInput.GetUp(OVRInput.Button.PrimaryHandTrigger))
            {
                part1.SetActive(false);
                if (!part2)
                {
                    part2 = Instantiate(textTemplate, this.transform);
                    part2.GetComponent<Text>().text = paragraph[19];
                    part2.GetComponent<Text>().alignment = TextAnchor.MiddleCenter;
                } else if (part2.active == false)
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

        else if (check == 2)
        {
            part2.SetActive(true);
            if (OVRInput.GetUp(OVRInput.Button.PrimaryHandTrigger))
            {
                part2.SetActive(false);
                if (!part3)
                {
                    part3 = Instantiate(textTemplate, this.transform);
                    part3.GetComponent<Text>().text = paragraph[20];
                    part3.GetComponent<Text>().alignment = TextAnchor.MiddleCenter;
                }
                else if (part3.active == false)
                {
                    part3.SetActive(true);
                }
                check = 3;
            }   
        }

        //part3 back to part2
        else if (check == 3 && OVRInput.GetUp(OVRInput.Button.PrimaryIndexTrigger))
        {
            part3.SetActive(false);
            check = 2;
        }

        else if (check == 3)
        {
            part3.SetActive(true);
            if (OVRInput.GetUp(OVRInput.Button.PrimaryHandTrigger))
            {
                part3.SetActive(false);
                if (!part4)
                {
                    part4 = Instantiate(textTemplate, this.transform);
                    part4.GetComponent<Text>().text = paragraph[21];
                    part4.GetComponent<Text>().alignment = TextAnchor.MiddleCenter;
                }
                else if (part4.active == false)
                {
                    part4.SetActive(true);
                }
                check = 4;
            }
        }

        //part4 back to part3
        else if (check == 4 && OVRInput.GetUp(OVRInput.Button.PrimaryIndexTrigger))
        {
            part4.SetActive(false);
            check = 3;
        }

        else if (check == 4)
        {
            part4.SetActive(true);
            if (OVRInput.GetUp(OVRInput.Button.PrimaryHandTrigger))
            {
                part4.SetActive(false);
                if (!part5)
                {
                    part5 = Instantiate(textTemplate, this.transform);
                    part5.GetComponent<Text>().text = paragraph[22];
                    part5.GetComponent<Text>().alignment = TextAnchor.MiddleCenter;
                }
                else if (part5.active == false)
                {
                    part5.SetActive(true);
                }
                check = 5;
            }
        }

        //part5 back to part4
        else if (check == 5 && OVRInput.GetUp(OVRInput.Button.PrimaryIndexTrigger))
        {
            part5.SetActive(false);
            check = 4;
        }

        else if (check == 5)
        {
            part5.SetActive(true);
            if (OVRInput.GetUp(OVRInput.Button.PrimaryHandTrigger))
            {
                part5.SetActive(false);
                if (!part6)
                {
                    part6 = Instantiate(textTemplate, this.transform);
                    part6.GetComponent<Text>().text = paragraph[23];
                    part6.GetComponent<Text>().alignment = TextAnchor.MiddleCenter;
                }
                else if (part6.active == false)
                {
                    part6.SetActive(true);
                }
                check = 6;
            }
        }

        //part6 back to part6
        else if (check == 6 && OVRInput.GetUp(OVRInput.Button.PrimaryIndexTrigger))
        {
            part6.SetActive(false);
            check = 5;
        }

        else if (OVRInput.GetUp(OVRInput.Button.PrimaryHandTrigger) && check ==6)
        {
            nextText.SetActive(true);
        }
    }

    // go back to the front Texts
    void backToFrontText()
    {
        if (OVRInput.GetUp(OVRInput.Button.PrimaryIndexTrigger))
        {
            preText.SetActive(true);
            preText.GetComponent<LoadTextLittleBoy>().rollBackCheck(1);
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
