using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeavesGrowController_tree3 : MonoBehaviour {
    private Material leavesMaterial2;
    private float cutoffValue;

    // Use this for initialization
    void Start () {
        leavesMaterial2 = Resources.Load<Material>("Materials/Optimized Leaf Material2"); //get leaves material
        cutoffValue = leavesMaterial2.GetFloat("_Cutoff");
    }
	
	// Update is called once per frame
	void Update () {
        if (leavesMaterial2.GetFloat("_Cutoff") > 0.3)
        {
            float speed = Random.Range(0.0002f, 0.002f);

            cutoffValue -= speed;

            leavesMaterial2.SetFloat("_Cutoff", cutoffValue);
        }
    }
}