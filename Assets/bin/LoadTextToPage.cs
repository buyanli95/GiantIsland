using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LoadTextToPage : MonoBehaviour {

    public Text pageTemplate;
    public Transform unRead;
    public string storybook;

    //keep txt file content
    private string myTXT;

    private string myPage;
    private int wordSum;
    private int maxWords;

	// Use this for initialization
	void Start () {
        myTXT = ((TextAsset)Resources.Load(storybook)).text;
        string[] sentence = myTXT.Split('.');

        //add . back
        sentenceAmend(sentence);

        wordSum = 0;
        myPage = null;
        maxWords = 400;
        for (int i = 0; i < sentence.Length; i++){
            //print(sentence[i].Length);

            wordSum += sentence[i].Length;

            if(wordSum < maxWords && i != sentence.Length - 1){
                AddToString(sentence[i]);
            }else if(wordSum< maxWords && i == sentence.Length - 1){
                AddToString(sentence[i]);
                createPage();
                break;
            }else if (wordSum >= maxWords || i != sentence.Length - 1)
            {
                createPage();

                wordSum += sentence[i].Length;
                AddToString(sentence[i]);

                //print("after create a page, the NEW page is: " + myPage);
            }
        }
	}

    //creat new page text
    void AddToString(string s){
        myPage += s;
        //print(myPage);
    }

    //create new Text object(i.e. page)
    void createPage(){
        Text textobj = Instantiate(pageTemplate, unRead.transform);

        textobj.alignment = TextAnchor.MiddleLeft;

        Image img = textobj.GetComponentInChildren<Image>();
        img.rectTransform.sizeDelta = new Vector2(440, 180);

        textobj.text = myPage;
        myPage = null;
        wordSum = 0;
    }

    //add . back to end of each sentence
    void sentenceAmend(string[] sentence){
        for (int i = 0; i < sentence.Length-1; i++){
            sentence[i] += ".";
        }
    }
}
