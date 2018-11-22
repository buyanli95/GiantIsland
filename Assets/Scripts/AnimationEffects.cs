using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AnimationEffects : MonoBehaviour {

    public Light lt;
    public Button Homebutton;

    public void checkEffects(Text[] Pages, Text targetPage, GameObject readSpot, GameObject unreadSpot)
    {
        GameObject effect;

        if (targetPage.text.ToLower().Contains("snow"))
        {
            transform.Find("snowflake").gameObject.SetActive(true);
            //effect = (GameObject)Resources.Load("Animations/Effects/snowflake", typeof(GameObject));
            if (Pages[0].IsActive())
            {
                transform.Find("snowflake").gameObject.SetActive(false);
            }
        }

        //if sparks
        if (targetPage.text.ToLower().Contains("spark"))
        {
            effect = transform.Find("sparks").gameObject;
            effect.SetActive(true);

            

            if (targetPage.transform.position == readSpot.transform.position || targetPage.transform.position == unreadSpot.transform.position)
            {
                effect.SetActive(false);
            }
        }

        //change light
        if (targetPage.text.ToLower().Contains("dark"))
        {
            float speed = 1/10;

            //front
            if (Pages[0].IsActive() && lt.intensity < 1.3)
            {
                lt.intensity += Time.deltaTime / 10;
            }
            else
            {
                lt.intensity = lt.intensity - Time.deltaTime / 10;
            }
        }
    }


    public void stopEffetcs()
    {
        print("stop effects");
        transform.Find("snowflake").gameObject.SetActive(false);
            
        if (lt.intensity < 1.3)
            {
                lt.intensity = lt.intensity + Time.deltaTime / 10;
            }
    }
}
