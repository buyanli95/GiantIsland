using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class treeController : MonoBehaviour {
    public GameObject[] templateList;
    public Transform launchPosition;

    private int treeAmount;
    private float distance;
    
    private float cutoffValue;

    // Use this for initialization
    void Start()
    {
        treeAmount = 1;
        distance = 80f;

        //keep trees leaves
        Resources.Load<Material>("Materials/Optimized Leaf Material").SetFloat("_Cutoff", 0.3f);
        Resources.Load<Material>("Materials/Optimized Leaf Material2").SetFloat("_Cutoff", 0.3f);
    }

    // Update is called once per frame
    void Update () {

        if (treeAmount < 12)
        {
            InvokeRepeating("Newobj", 1, 1);
        }
        else
        {
            CancelInvoke();
        }
    }

    void Newobj()
    {
        int treeNo = Random.Range(0, 3);
        //launchPosition.position = new Vector3(Random.Range(-1f, 1f), 0, Random.Range(-1f, 1f));
        GameObject one = Instantiate(templateList[treeNo], launchPosition);
        
        if(treeAmount < 6)
        {
            //one.transform.position = new Vector3(Random.Range(-500f, 600f), 20f, Random.Range(-100f, 600f));
            one.transform.position = new Vector3(-260f, -80f, 150f - distance);
            distance += 80f;
        }
        else if(treeAmount >= 6)
        {
            distance -= 80f;    
            one.transform.position = new Vector3(260f, -80f, 150f - distance);
           
        }

        one.SetActive(true);
       
        treeAmount++;
        
    }
}
