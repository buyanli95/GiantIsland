using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class leavesTrigger : MonoBehaviour {

    private void OnTriggerEnter(Collider other)
    {
        this.GetComponent<LeavesFallController_tree3>().enabled = false;
        this.GetComponent<LeavesGrowController_tree3>().enabled = true;
    }

    private void OnTriggerStay(Collider other)
    {
        this.GetComponent<LeavesFallController_tree3>().enabled = false;
        this.GetComponent<LeavesGrowController_tree3>().enabled = true;
    }

    private void OnTriggerExit(Collider other)
    {
        this.GetComponent<LeavesGrowController_tree3>().enabled = false;
        this.GetComponent<LeavesFallController_tree3>().enabled = true;
    }

    

    
}
