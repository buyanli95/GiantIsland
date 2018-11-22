using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

//set LoadTextToPage to be excuted before this script
public class LerpPageFreely_New : MonoBehaviour {
    public Light lt;
    //boundary of reading space
    public GameObject readSpot;
    public GameObject unreadSpot;

    public GameObject Effects;
    public GameObject ButtonManager;

    //page on the move
    private Text targetPage;
    private Vector3 offfset;

    //for lerp
    public float speed;
    private float startTime;
    private float journeyLength;
    //private float journeyLength2;

    //grab generated Text pages
    private Text[] Pages;

    //quick access to front/next page
    public GameObject HomeButton;
    public GameObject FrontButton;
    public GameObject template;

    //--------------------------------------------------------------------------------
    void Start () {
        Pages = unreadSpot.GetComponentsInChildren<Text>(); //get pages in an arrary
        targetPage = null; //page being read
        startTime = Time.time; //for lerp
        offfset = new Vector3(10, 0, 0);
        template.transform.position = FrontButton.transform.position;
	}

    //--------------------------------------------------------------------------------
    // Update is called once per frame
    void Update () {
        
        //set next button
        for(int i=1; i<Pages.Length; i++){
            //if(Pages[i].transform.position == readSpot.transform.position){
            if(Pages[Pages.Length-1].transform.position == readSpot.transform.position){
                HomeButton.SetActive(true);
                Effects.GetComponent<AnimationEffects>().stopEffetcs();
               
            }
            else {
                HomeButton.SetActive(false);
            }

       
        }

        //set front button
        for(int i=1; i<Pages.Length; i++){
            if (Pages[i].transform.position == unreadSpot.transform.position){
                template.SetActive(true);
            }
            else{
                template.SetActive(false);
                break;
            }
        }
        //--------------------------------------------------------------------------------
        //move page leftwards
        //if (Input.GetKey(KeyCode.A))
        if (OVRInput.Get(OVRInput.Button.PrimaryHandTrigger))
        {
            for (int i = 1; i < Pages.Length; i++)
            {
                //pages can be move leftwards
                if (Pages[i].transform.position != readSpot.transform.position)
                {
                    targetPage = Pages[i];
                    movePageFreely("Left");
                    break;
                }
            }
        }

        //move page rightwards
        else if (OVRInput.Get(OVRInput.Button.PrimaryIndexTrigger))
        //else if (Input.GetKey(KeyCode.D))
        {
            for (int i = Pages.Length - 1; i >= 1; i--)
            {
                //pages can be move rightwards
                if (Pages[i].transform.position != unreadSpot.transform.position)
                {
                    targetPage = Pages[i];
                    //offfset += new Vector3(10, 10, 10);
                    movePageFreely("Right");
                    break;
                }
            }
        }

        //--------------------------------------------------------------------------------
        //check text effects
        Effects.GetComponent<AnimationEffects>().checkEffects(Pages, targetPage, readSpot, unreadSpot);

        //check double/triple click to get quick access to other scenes
        OnGUI();
	}

    //--------------------------------------------------------------------------------
    //move pages
    void movePageFreely(string dir)
    {
        if (dir == "Left"){ //move left
            journeyLength = Vector3.Distance(targetPage.transform.position, readSpot.transform.position);
            //float distCovered = (Time.time - startTime) * speed;
            float distCovered = 500 * speed;
            float fracJourney = distCovered / journeyLength;

            float step = speed * Time.deltaTime;

            //targetPage.transform.position = Vector3.Lerp(targetPage.transform.position, readSpot.transform.position, fracJourney);
            targetPage.transform.position = Vector3.MoveTowards(targetPage.transform.position, readSpot.transform.position, step);
        }
        else if (dir == "Right"){ //move right

            journeyLength = Vector3.Distance(targetPage.transform.position, unreadSpot.transform.position);
            //float distCovered = (Time.time - startTime) * speed;
            float distCovered = 500 * speed;
            float fracJourney = distCovered / journeyLength;
            float step = speed * Time.deltaTime;

            //targetPage.transform.position = Vector3.Lerp(targetPage.transform.position, unreadSpot.transform.position, fracJourney);
            targetPage.transform.position = Vector3.MoveTowards(targetPage.transform.position, unreadSpot.transform.position, step);
        }
    }

    //--------------------------------------------------------------------------------
    //quick access to the other scene
    void OnGUI()
    {
        //double click - next 
        //if (Event.current.isMouse && Event.current.type == EventType.MouseDown && Event.current.clickCount == 2)
        if(OVRInput.Get(OVRInput.Button.SecondaryHandTrigger))
        {
            //foreach (Text item in Pages)
            for(int i=1; i<Pages.Length; i++)
            {
                Pages[i].transform.position = readSpot.transform.position;
            }
        }
        //triple click - front
        //if (Event.current.isMouse && Event.current.type == EventType.MouseDown && Event.current.clickCount == 3)
        if (OVRInput.Get(OVRInput.Button.SecondaryIndexTrigger))
        {
            for (int i = 1; i < Pages.Length; i++)
            {
                Pages[i].transform.position = unreadSpot.transform.position;
                //template.SetActive(true);
            }
        }
    }
}
