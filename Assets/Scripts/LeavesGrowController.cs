using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeavesGrowController : MonoBehaviour {
    private Material leavesMaterial;
    private float cutoffValue;
    private float speed;
    // Use this for initialization
    void Start () {

        //GetComponent<LeavesFallController>().enabled = false;

        //get leaves material
        leavesMaterial = Resources.Load<Material>("Materials/Optimized Leaf Material");

        //get alpha cutoff value
        cutoffValue = leavesMaterial.GetFloat("_Cutoff");
    }
	
	// Update is called once per frame
	void Update () {


        if (leavesMaterial.GetFloat("_Cutoff") > 0.3)
        {
            //set growing speed
            speed = Random.Range(0.0002f, 0.002f);
            cutoffValue -= speed;

            leavesMaterial.SetFloat("_Cutoff", cutoffValue);
        }

    }
}
