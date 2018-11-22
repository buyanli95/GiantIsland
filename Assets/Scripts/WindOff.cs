using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WindOff : MonoBehaviour {
    public float TurbulanceMin;
	// Update is called once per frame
	void Update () {
		if(this.GetComponent<WindZone>().windTurbulence > TurbulanceMin)
        {
            this.GetComponent<WindZone>().windTurbulence -= Time.deltaTime;
        }
	}
}
