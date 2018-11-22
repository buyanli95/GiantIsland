using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeavesFallController : MonoBehaviour {

    private Material leavesMaterial;
    private Material leavesMaterial2;

    private float cutoffValue;
    private float cutoffValue2;
    private float speed;

	// Use this for initialization
	void Start () {
        //GetComponent<LeavesGrowController>().enabled = false;
        leavesMaterial = Resources.Load<Material>("Materials/Optimized Leaf Material"); //get leaves material
        leavesMaterial2 = Resources.Load<Material>("Materials/Optimized Leaf Material2"); //get leaves material

        cutoffValue = leavesMaterial.GetFloat("_Cutoff"); //get alpha cutoff value
        cutoffValue2 = leavesMaterial2.GetFloat("_Cutoff");
    }
	
	// Update is called once per frame
    void Update () {

        if (leavesMaterial.GetFloat("_Cutoff") <1.1){
            speed = Random.Range(0.0002f, 0.002f);

            cutoffValue += speed;

            leavesMaterial.SetFloat("_Cutoff", cutoffValue);
        }

        if (leavesMaterial2.GetFloat("_Cutoff") < 1.1)
        {
            speed = Random.Range(0.0002f, 0.002f);

            cutoffValue2 += speed;

            leavesMaterial2.SetFloat("_Cutoff", cutoffValue2);
        }
    }
}
