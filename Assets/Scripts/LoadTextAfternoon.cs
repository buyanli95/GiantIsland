using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LoadTextAfternoon : MonoBehaviour {

    public GameObject afternoon;

    public GameObject Home;
    public GameObject preText;
    public GameObject preText2;
    public GameObject TextRoot;
    public GameObject textTemplate;

    public GameObject nextText;
 
    public string BookAsset;
    private string[] paragraph;

    private void Start()
    { 
        //preText.SetActive(false);
        //preText2.SetActive(false);

        paragraph = ((TextAsset)Resources.Load(BookAsset)).text.Split('\n');

        GameObject obj = Instantiate(textTemplate, this.transform);
        obj.GetComponent<Text>().text = paragraph[2];
        obj.GetComponent<Text>().alignment = TextAnchor.MiddleCenter;
    }

    private void Update()
    {
        preText.SetActive(false);
        afternoon.SetActive(true);
        //check input
        grassEffect();
        backToFrontText();
    }

    public void grassEffect(){
        if (OVRInput.GetUp(OVRInput.Button.PrimaryHandTrigger))
        {
            TextRoot.transform.Find("Spot-grass").gameObject.SetActive(true);
            //nextTextEffect.SetActive(true);
        }
    }

    // go back to the front Texts
    void backToFrontText()
    {
        if (OVRInput.GetUp(OVRInput.Button.PrimaryIndexTrigger)){
            
            afternoon.SetActive(false);
            preText.SetActive(true);
            preText2.SetActive(true);
            Home.GetComponent<LoadTextByWord>().rollBackCheck(1);
        }
    }

    //actived by its next Text, destroy the next Text, and enable current effects
    public void rollBackCheck(int flag)
    {
        if (flag == 1)
        {
            nextText.SetActive(false);
            afternoon.SetActive(true);
        }
    }
}
