using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LoadTextGrass : MonoBehaviour {

    public GameObject preText;
    public GameObject TextRoot;
    public GameObject textTemplate;

    public GameObject nextText;
  
    //effect
    public GameObject grass;

    public string BookAsset;
    private string[] paragraph;
    private string[] sentence;

    // Use this for initialization
    void Start () {
        //preText.SetActive(false);

        paragraph = ((TextAsset)Resources.Load(BookAsset)).text.Split('\n');
        sentence = paragraph[3].Split('.');

        GameObject obj = Instantiate(textTemplate, this.transform);
        obj.GetComponent<Text>().text = sentence[0] + ". ";
        obj.GetComponent<Text>().alignment = TextAnchor.MiddleCenter;
    }
	
	// Update is called once per frame
	void Update () {
        preText.SetActive(false);
        grass.SetActive(true);

        //check input
        flowerEffect();
        backToFrontText();
    }

    void flowerEffect(){
        if (OVRInput.GetUp(OVRInput.Button.PrimaryHandTrigger))
        {
            TextRoot.transform.Find("Spot-flower").gameObject.SetActive(true);
        }
    }

    // go back to the front Texts
    void backToFrontText()
    {
        if (OVRInput.GetUp(OVRInput.Button.PrimaryIndexTrigger))
        {
            grass.SetActive(false);
            preText.SetActive(true);
            preText.GetComponent<LoadTextAfternoon>().rollBackCheck(1);        
        }
    }

    //actived by its next Text, destroy the next Text, and enable current effects
    public void rollBackCheck(int flag)
    {
        if (flag == 1)
        {
            nextText.SetActive(false);
            grass.SetActive(true);
        }
    }
}
