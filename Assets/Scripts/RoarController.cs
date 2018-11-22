using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoarController : MonoBehaviour {
    private float seconds;
	// Use this for initialization
	void Start () {

        seconds = 0;
    }

   

    private void FixedUpdate()
    {
        //StartCoroutine(waiting());
        if (GetComponent<AudioSource>().volume > 0 && seconds < 20)
        {
            
            seconds++;
        }else if(seconds >= 20)
        {
            GetComponent<AudioSource>().volume -= Time.deltaTime * 0.1f;
        }
    }

    IEnumerator waiting()
    {
        yield return new WaitForSeconds(seconds);
    }

}
