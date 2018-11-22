using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LerpPageFreely : MonoBehaviour {
    //the page list
    public GameObject[] Pages;

    //boundary of reading space
    public Transform readSpot;
    public Transform unreadSpot;

    //page on the move
    private GameObject targetPage;

    //for lerp
    public float speed;
    private float startTime;
    private float journeyLength;
    private float journeyLength2;

	// Use this for initialization
	void Start () {
        targetPage = null;
        startTime = Time.time;
	}
	
	// Update is called once per frame
	void Update () {
        //if user want to move page leftwards
        if(Input.GetKey(KeyCode.A)){
            for (int i = 0; i < Pages.Length; i++){
                //pages can be move leftwards
                if(Pages[i].transform.position != readSpot.position){
                    targetPage = Pages[i];
                    movePageFreely("Left");
                    break;
                }
            }
        }

        //if user want to move page rightwards
        else if(Input.GetKey(KeyCode.D)){
            for (int i = Pages.Length-1; i >=0; i--){
                //pages can be move rightwards
                if (Pages[i].transform.position != unreadSpot.position)
                {
                    targetPage = Pages[i];
                    movePageFreely("Right");
                    break;
                }
            }
        }
	}

    void movePageFreely(string dir){
        
        if(dir == "Left"){ //move left
            journeyLength = Vector3.Distance(targetPage.transform.position, readSpot.position);
            float distCovered = (Time.time - startTime) * speed;
            float fracJourney = distCovered / journeyLength;

            targetPage.transform.position = Vector3.Lerp(targetPage.transform.position, readSpot.position, fracJourney);

        }else if(dir == "Right"){ //move right
            
            journeyLength = Vector3.Distance(targetPage.transform.position, unreadSpot.position);
            float distCovered = (Time.time - startTime) * speed;
            float fracJourney = distCovered / journeyLength;

            targetPage.transform.position = Vector3.Lerp(targetPage.transform.position, unreadSpot.position, fracJourney);
        }
    }
}

           

            
      