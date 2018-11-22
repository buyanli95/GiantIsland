using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LoadTextByWord : MonoBehaviour {
    public GameObject userGuide;

    public GameObject TextRoot;
    public GameObject titleSpot;
    public GameObject authorSpot;
    public GameObject textTemplate;
    public string BookAsset;

    private string myTXT;
    private string[] paragraph;

    public GameObject nextText;
  
    // Use this for initialization
    void Start () {
        userGuide.SetActive(false);

        myTXT = ((TextAsset)Resources.Load(BookAsset)).text;
        paragraph = myTXT.Split('\n');

        //title
        GameObject obj_title = Instantiate(textTemplate, titleSpot.transform);
        obj_title.GetComponent<Text>().text = paragraph[0];
        obj_title.GetComponent<Text>().alignment = TextAnchor.MiddleCenter;
        obj_title.GetComponent<Text>().material.color = Color.white;

        //author
        GameObject obj_au = Instantiate(textTemplate, authorSpot.transform);
        obj_au.GetComponent<Text>().text = paragraph[1];
        obj_au.GetComponent<Text>().alignment = TextAnchor.MiddleCenter;
       
    }

    private void Update()
    {
        //afternoon
        if (OVRInput.GetUp(OVRInput.Button.PrimaryHandTrigger))
        {
            textTemplate.GetComponent<Text>().text = null;
            titleSpot.SetActive(false);
            authorSpot.SetActive(false);
            //TextRoot.GetComponentInChildren<LoadTextByWord>()

            //get next text funnction
            TextRoot.transform.Find("Spot-afternoon").gameObject.SetActive(true);
            //nextTextEffect.SetActive(true);
        }
    }

    public void rollBackCheck(int flag)
    {
        if(flag == 1)
        {
            nextText.SetActive(false);
        }
    }

}
